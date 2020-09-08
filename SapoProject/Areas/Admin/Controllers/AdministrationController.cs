using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;

namespace SapoProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administration")]
    public class AdministrationController : Controller
    {
        private readonly IAdministrationRepository _advertisementRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdministrationController(IAdministrationRepository administrationRepository, ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _advertisementRepository = administrationRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        // GET: AdministrationController/ListRole
        [HttpGet]
        public ActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        // GET: AdministrationController/Edit/5
        [HttpGet]
        public async Task<ActionResult> EditRole(String id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData["Message"] = "Không có vai trò với id= " + id;
                return View("NotFound");
            }
            else
            {
                var model = new UserRoleEdit
                {
                    Id = role.Id,
                    RoleName = role.Name,

                };
                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        model.Users.Add(user.UserName);
                    }
                }
                return View(model);
            }
        }

        // POST: AdministrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRole(UserRoleEdit userRoleEdit)
        {
            var role = await _roleManager.FindByIdAsync(userRoleEdit.Id);
            if (role == null)
            {
                TempData["Message"] = "Không có vai trò với id= " + userRoleEdit.Id;
                return View("NotFound");
            }
            else
            {
                role.Name = userRoleEdit.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                var error = result.Errors.ToList(); //convert to list
                foreach (var err in error) //iterate through individual error
                {
                    ModelState.AddModelError("", err.Description);
                    _logger.LogError(err.Description + " EditRole");
                }

                return View(userRoleEdit);
            }

        }


        [HttpGet]
        public async Task<ActionResult> EditUserInRole(String roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                TempData["Message"] = "Không có vai trò với id= " + roleId;
                return View("NotFound");
            }
            else
            {
                var model = new List<UserRoleChange>();

                foreach (var user in _userManager.Users)
                {
                    var userRoleChange = new UserRoleChange()
                    {
                        UserId = user.Id,
                        UserName = user.UserName,

                    };
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRoleChange.IsSelected = true;
                    }
                    else
                    {
                        userRoleChange.IsSelected = false;

                    }
                    model.Add(userRoleChange);
                }

                return View(model);
            }
        }
        [HttpPost]
        public async Task<ActionResult> EditUserInRole(List<UserRoleChange> userRoleChanges, String roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                TempData["Message"] = "Không có vai trò với id= " + roleId;
                return View("NotFound");
            }
            else
            {
                for (int index = 0; index < userRoleChanges.Count; index++)
                {
                    IdentityResult identityResult = null;
                    var user = await _userManager.FindByIdAsync(userRoleChanges[index].UserId);
                    if (userRoleChanges[index].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        identityResult = await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!userRoleChanges[index].IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        identityResult = await _userManager.RemoveFromRoleAsync(user, role.Name);

                    }
                    else
                    {
                        continue;
                    }
                    if (identityResult.Succeeded)
                    {
                        if (index < userRoleChanges.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            return RedirectToAction("EditRole", new { id = roleId });
                        }
                    }
                }
                return RedirectToAction("EditRole", new { id = roleId });
            }
        }

        // GET: AdministrationController/CreateRole
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
        // GET: AdministrationController/CreateRole
        [HttpPost]
        public async Task<ActionResult> CreateRoleAsync(UserRoleCreate userRoleCreate)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = userRoleCreate.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Product");
                }
                else
                {
                    var error = result.Errors.ToList(); //convert to list
                    foreach (var err in error) //iterate through individual error
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View(userRoleCreate);

        }
        // POST: AdministrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: AdministrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

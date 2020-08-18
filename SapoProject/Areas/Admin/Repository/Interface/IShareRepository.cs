using System;
using SapoProject.Model.Entities;

namespace SapoProject.Areas.Admin.Repository.Interface
{
    public interface ISharedRepository : IDisposable
    {
        public User getUserLogin();
    }
}

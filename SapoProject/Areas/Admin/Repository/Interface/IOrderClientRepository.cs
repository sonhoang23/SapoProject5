using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Interface
{
    public interface IOrderClientRepository
    {
        List<OrderClient> GetOrder();
        string GetClientNameById(int clientId);
        string GetClientPhoneNumberById(int clientId);
        String SwitchStatus(int status);
        List<OrderClient> GetOrderByFilterAndSearchString(string orderFilter, string searchString);
    }
}

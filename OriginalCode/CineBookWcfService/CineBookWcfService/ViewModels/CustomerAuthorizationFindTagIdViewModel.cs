using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using CineBookWcfService.Models;

namespace CineBookWcfService.ViewModels
{
    public class CustomerAuthorizationFindTagIdViewModel
    {
        public bool Result { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public static CustomerAuthorizationFindTagIdViewModel Get(string serialNumber)
        {
            CustomerAuthorizationFindTagIdViewModel result = null;
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    result = entities.Database.SqlQuery<CustomerAuthorizationFindTagIdViewModel>("sp_CustomerAuthorization_FindTagId @Parameter", new SqlParameter("@Parameter", serialNumber)).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
#if DEBUG
                result = new CustomerAuthorizationFindTagIdViewModel { Result = true, Content = serialNumber, Description = serialNumber };
#endif
            }
            return result;
        }
    }
}
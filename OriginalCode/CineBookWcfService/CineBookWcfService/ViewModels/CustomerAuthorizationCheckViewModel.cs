using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using CineBookWcfService.Models;

namespace CineBookWcfService.ViewModels
{
    public class CustomerAuthorizationCheckViewModel
    {
        public bool Result { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }

        public static CustomerAuthorizationCheckViewModel GetForBooking(string tagId, int sessionId)
        {
            CustomerAuthorizationCheckViewModel result = null;
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    result = entities.Database.SqlQuery<CustomerAuthorizationCheckViewModel>("sp_CustomerAuthorization_CheckForBooking @Parameter,@MovieSessionId", new SqlParameter("@Parameter", tagId), new SqlParameter("@MovieSessionId", sessionId)).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
#if DEBUG
                result = new CustomerAuthorizationCheckViewModel { Result = true, Content = tagId, Description = tagId };
#endif
            }
            return result;
        }
    }
}
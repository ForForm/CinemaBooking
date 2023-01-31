using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace CinemaBooking.Model
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
                using (var entities = new CinemaBookingEntities())
                {
                    result = entities.Database.SqlQuery<CustomerAuthorizationFindTagIdViewModel>("sp_CustomerAuthorization_FindTagId @Parameter", new SqlParameter("@Parameter", serialNumber)).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                StaticClass.WriteToLog(exception.ToString(), "Exception", true, true, true);
                if (Debugger.IsAttached) result = new CustomerAuthorizationFindTagIdViewModel { Result = true, Content = serialNumber, Description = serialNumber };
            }
            return result;
        }

    }
}

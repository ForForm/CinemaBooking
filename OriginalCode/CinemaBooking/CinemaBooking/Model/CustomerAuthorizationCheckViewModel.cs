using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace CinemaBooking.Model
{
    public class CustomerAuthorizationCheckViewModel
    {
        public bool Result { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }

        public static CustomerAuthorizationCheckViewModel Get(string tagId)
        {
            CustomerAuthorizationCheckViewModel result = null;
            try
            {
                using (var entities = new CinemaBookingEntities())
                {
                    result = entities.Database.SqlQuery<CustomerAuthorizationCheckViewModel>("sp_CustomerAuthorization_Check @Parameter", new SqlParameter("@Parameter", tagId)).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                StaticClass.WriteToLog(exception.ToString(), "Exception", true, true, true);
            }
            if (Debugger.IsAttached)
                result = new CustomerAuthorizationCheckViewModel { Result = true, Content = tagId, Description = tagId };
            return result;
        }
        public static CustomerAuthorizationCheckViewModel GetForBooking(string tagId, int movieSessionId)
        {
            CustomerAuthorizationCheckViewModel result = null;
            try
            {
                using (var entities = new CinemaBookingEntities())
                {
                    result = entities.Database.SqlQuery<CustomerAuthorizationCheckViewModel>("sp_CustomerAuthorization_CheckForBooking @Parameter,@MovieSessionId", new SqlParameter("@Parameter", tagId), new SqlParameter("@MovieSessionId", movieSessionId)).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                StaticClass.WriteToLog(exception.ToString(), "Exception", true, true, true);
            }
            if (Debugger.IsAttached)
                result = new CustomerAuthorizationCheckViewModel { Result = true, Content = tagId, Description = tagId };
            return result;
        }

    }
}

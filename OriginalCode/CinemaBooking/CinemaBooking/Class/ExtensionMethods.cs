using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CinemaBooking
{
    public static class ExtensionMethods
    {
        //public static string ComputeSHA512(this string value)
        //{
        //    if (string.IsNullOrEmpty(value)) throw new ArgumentNullException();
        //    var buffer = Encoding.UTF8.GetBytes(value);
        //    buffer = System.Security.Cryptography.SHA512.Create().ComputeHash(buffer);
        //    return Convert.ToBase64String(buffer).Substring(0, 86);
        //}
        public static string ComputeHash(this string password)
        {
            var returnValue = "";
            if (password == null) return returnValue;
            using (var hashAlg = new SHA1Managed())
            {
                var pwordData = Encoding.Default.GetBytes(password);
                var hash = hashAlg.ComputeHash(pwordData);
                returnValue = BitConverter.ToString(hash).Replace("-", "");
            }
            return returnValue;
        }
        public static Image ToImage(this byte[] value)
        {
            Image result = null;
            try
            {
                result = (Bitmap)new ImageConverter().ConvertFrom(value);
            }
            catch (Exception)
            {
            }
            return result;
        }
        public static void MaximizeToSecondaryMonitor(this Form window)
        {
            var secondaryScreen = Screen.AllScreens.FirstOrDefault(o => !o.Primary);
            if (secondaryScreen != null)
            {
                window.StartPosition = FormStartPosition.Manual;
                var workingArea = secondaryScreen.WorkingArea;
                window.Left = workingArea.Left;
                window.Top = workingArea.Top;
                window.Width = workingArea.Width;
                window.Height = workingArea.Height;
                // If window isn't loaded then maxmizing will result in the window displaying on the primary monitor
                window.WindowState = FormWindowState.Maximized;
            }
        }
        public static string CropIfItsLong(this string value, int charCount)
        {
            var result = value;
            if (result.Length > charCount) result = result.Substring(0, charCount - 3) + "...";
            return result;
        }
        public static string JsonSerialize(this object objectClass)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(objectClass);
        }

        public static DateTime GetDate(this CinemaBookingEntities entities)
        {
            var result = DateTime.Now;
            try
            {
                result = entities.Database.SqlQuery<DateTime>("SELECT GetDate();").FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }

        

 

        public static string ChangeLng(this string value)
        {
            using (var entities = new CinemaBookingEntities())
            {
                var item = entities.LabelDictionary.Where(o => o.LanguagesId == LoginUser.LoggedLanguagesId && value == o.Label).FirstOrDefault();

                

                if (item == null)
                {
                    int activeLng = entities.Languages.Where(o => o.Active == true).FirstOrDefault().Id;
                    item = entities.LabelDictionary.Where(o => o.LanguagesId == activeLng && value == o.Label).FirstOrDefault();
                    if (item != null)
                        return item.LabelLng;
                    else
                        return value;
                }
                else  return item.LabelLng;
            }
        }

    }
}

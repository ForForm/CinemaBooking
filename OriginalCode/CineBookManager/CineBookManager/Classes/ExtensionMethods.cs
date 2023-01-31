using CineBookManager.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CineBookManager.Classes
{
    public static class ExtensionMethods
    {
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
        public static byte[] ToByteArray(this Image value)
        {
            byte[] result = null;
            try
            {
                result = (byte[])new ImageConverter().ConvertTo(value, typeof(byte[]));
            }
            catch (Exception)
            {
            }
            return result;
        }
        public static string GetImageResolution(this Image image)
        {
            var result = "0x0";
            if (image != null) result = image.Size.Width + "x" + image.Size.Height;
            return result;
        }
        public static string GetImageSizeKB(this Image image)
        {
            var result = "0 KB";
            if (image != null)
            {
                var len = image.ToByteArray().Length / 1024;
                result = len + " KB";
            }
            return result;
        }


        public static string ChangeLng(this string value)
        {
            using (var entities = new CineBookEntities())
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
                else
                { return item.LabelLng; }
            }
        }

        public static string CropIfItsLong(this string value, int charCount)
        {
            var result = value;
            if (result.Length > charCount) result = result.Substring(0, charCount - 3) + "...";
            return result;
        }
    }
}

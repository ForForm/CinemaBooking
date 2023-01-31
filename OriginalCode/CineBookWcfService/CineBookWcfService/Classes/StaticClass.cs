using System;

namespace CineBookWcfService.Classes
{
    public class StaticClass
    {
        public static string GetNewBarcodeId() { return Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 10); }
    }
}
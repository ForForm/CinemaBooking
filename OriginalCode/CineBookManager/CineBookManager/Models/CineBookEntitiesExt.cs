namespace CineBookManager.Models
{
    public class CineBookEntitiesExt: CineBookEntities
    {
        public static CineBookEntities New(bool lazyLoading = false, bool proxyCreationEnabled = false)
        {
            var result = new CineBookEntities();
            result.Configuration.LazyLoadingEnabled = lazyLoading;
            result.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            return result;
        }
    }
}

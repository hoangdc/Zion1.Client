using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telerik.Blazor.Components.Pager;
using Zion1.Common.Helper.Api;
using Zion1.Common.Helper.Cache;

namespace Zion1.Client.Web.Share
{
    public static class ApiServices
    {
        private static InMemoryCache _cache = new InMemoryCache();

        public static IServiceCollection AddApiSettings(this IServiceCollection services, IConfiguration configuration)
        {
            ApiSettings = ApiHelper.GetApiSettings();
            return services;
        }

        public static ApiSettings ApiSettings
        {
            get
            {
                return _cache.Get<ApiSettings>("ApiSettings_Global");
            }
            set
            {
                _cache.Set("ApiSettings_Global", value, 24 * 60);
            }
        }
    }
}

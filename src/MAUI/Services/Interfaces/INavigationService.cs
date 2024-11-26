using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_MobileProject.Services.Repositories
{
    public interface INavigationService
    {
        Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);

        Task PopAsync();
    }
}

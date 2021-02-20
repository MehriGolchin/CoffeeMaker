using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CafeeMaker.Web.Services {

    public interface ILoginService {

        Task SignInAsync(IEnumerable<Claim> claims);

        Task SignOutAsync();

    }

}
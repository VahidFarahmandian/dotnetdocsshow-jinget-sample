using System.Security.Claims;
using System.Threading.Tasks;
using Jinget.Core.Contracts;
using MediatR;

namespace JingetSample.API
{
    public class PrincipalManager : ClaimsPrincipal, IUserContext
    {
        public PrincipalManager(IMediator mediator) { }

        public virtual async Task<bool> HasAccess(string userIdentifier, string subSystemName, string apiName, string actionTitle, string claim) => await Task.FromResult(true);

        public async Task<bool> IsTokenValid(string userIdentifier, string token) => await Task.FromResult(true);
    }
}
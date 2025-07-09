using Microsoft.AspNetCore.Authorization;

namespace OpenFindaBLE.Backend.Handlers
{
    public class DynamicRoleRequirement: IAuthorizationRequirement
    {
        public string Authority { get; }
        public DynamicRoleRequirement(string authority)
        {
            Authority = authority ?? throw new ArgumentNullException(nameof(authority));
        }
    }
}

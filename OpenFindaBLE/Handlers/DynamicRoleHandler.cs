using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace OpenFindaBLE.Backend.Handlers
{
    public class DynamicRoleHandler(ApplicationDbContext applicationDbContext): AuthorizationHandler<DynamicRoleRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicRoleRequirement requirement)
        {
            var roles = await applicationDbContext.Authorities
                .Where(x=>x.Name == requirement.Authority)
                .Select(a => a.Role).ToHashSetAsync();
            foreach(var role in roles)
            {
                if(role.Name == null)
                {
                    continue;
                }
                if (context.User.IsInRole(role.Name))
                {
                    context.Succeed(requirement);
                    return;
                }
            }
        }
    }
}

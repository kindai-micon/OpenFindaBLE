using Microsoft.AspNetCore.Authorization;
using System.Reflection;

namespace OpenFindaBLE.Backend.Services
{
    public class AuthorityScanService : IAuthorityScanService
    {
        public AuthorityScanService()
        {
            Scan();
        }
        public HashSet<string> Authority { get; private set; } = new HashSet<string>();
        Assembly Assembly = Assembly.GetExecutingAssembly(); 
        public void Scan()
        {
            var types = Assembly.GetTypes();
            foreach (var type in types)
            {
                var auths = type.GetCustomAttributes<AuthorizeAttribute>();
                foreach(var auth in auths)
                {
                    if (auth is not null && auth.Policy is not null)
                    {
                        Authority.Add(auth.Policy);
                    }
                }
                var authMethods = type.GetMethods();
                
                foreach(var method in authMethods)
                {
                    var authMethod = method.GetCustomAttributes<AuthorizeAttribute>();
                    foreach (var auth in authMethod)
                    {
                        if (auth is not null && auth.Policy is not null)
                        {
                            Authority.Add(auth.Policy);
                        }
                    }
                }

            }
        }
    }
}

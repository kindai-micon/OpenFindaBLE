namespace OpenFindaBLE.Backend.Services
{
    public interface IAuthorityScanService
    {
        public HashSet<string> Authority { get; }
        public void Scan();
    }
}

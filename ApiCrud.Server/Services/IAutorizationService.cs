using ApiCrud.Server.Models.Custom;

namespace ApiCrud.Server.Services
{
    public interface IAutorizationService
    {
        Task<AutorizationResponse> DevolverToken(AutorizationRequest autorization);
    }
}

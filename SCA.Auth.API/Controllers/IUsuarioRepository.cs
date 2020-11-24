using SCA.Auth.API.Model;

namespace SCA.Auth.API.Controllers
{
    public interface IUsuarioRepository
    {
        Usuario Get(string username, string password);
    }
}
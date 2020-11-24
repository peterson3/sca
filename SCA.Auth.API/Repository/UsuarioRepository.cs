using SCA.Auth.API.Controllers;
using SCA.Auth.API.Model;
using System.Linq;

namespace SCA.Auth.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AuthContext _context;

        public UsuarioRepository(AuthContext context)
        {
            _context = context;
        }

        public Usuario Get(string username, string password)
        {
            return _context.Usuarios.Where(x=>x.Username.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).FirstOrDefault();
        }
    }
}

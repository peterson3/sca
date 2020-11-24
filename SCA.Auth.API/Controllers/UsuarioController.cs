using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCA.Auth.API.Model;
using SCA.Auth.API.Repository;
using SCA.Auth.API.Services;

namespace SCA.Auth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
            
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public dynamic Get([FromBody] Usuario model)
        {
            var user = _usuarioRepository.Get(model.Username, model.Password);

            if (user == null)
            {
                return new { message = "Usuario ou senha inválido" };
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}

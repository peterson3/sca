using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCA.Ativos.API.Model;

namespace SCA.Ativos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly ILogger<AtivoController> _logger;

        public AtivoController(ILogger<AtivoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Ativo> Get()
        {
            return new List<Ativo>();
        }
    }
}

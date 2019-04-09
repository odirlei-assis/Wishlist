using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Wishlist.WebApi.Domains;
using Senai.Wishlist.WebApi.Repositories;

namespace Senai.Wishlist.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejosController : ControllerBase
    {
        private DesejoRepository DesejoRepository { get; set; }

        public DesejosController()
        {
            DesejoRepository = new DesejoRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Desejos desejo)
        {
            try
            {
                DesejoRepository.Cadastrar(desejo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message});
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(DesejoRepository.BuscaDesejoId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message });
            }
        }
    }
}
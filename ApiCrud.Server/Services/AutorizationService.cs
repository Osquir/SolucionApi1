/*using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiCrud.Server.Models;
using ApiCrud.Server.Models.Custom;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Server.Services
{
    public class AutorizationService : IAutorizationService
    {
        private readonly InstitucionContext _dbContext;
        private readonly IConfiguration _configuration;

        public AutorizationService(InstitucionContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        //Metodo para generar el token
        private string GenerarToken(string idUsuario)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));

            var credencialesToken = new SigningCredentials(
              new SymmetricSecurityKey(keyBytes),
              SecurityAlgorithms.HmacSha256Signature
              );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5), //Tiempo de vida de token
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            return tokenCreado;
        }

        public async Task<AutorizationResponse> DevolverToken(AutorizationRequest autorization)
        {
            var usuario_encontrado = _dbContext.Usuarios.FirstOrDefault(x =>
            x.Usuario1 == autorization.Usuario1 &&
            x.Contra == autorization.Contra);

            if (usuario_encontrado == null)
            {
                return await Task.FromResult<AutorizationResponse>(null);
            }

            string tokenCreado = GenerarToken(usuario_encontrado.IdUsuario.ToString());

            return new AutorizationResponse()
            {
                Token = tokenCreado,
                Resultado = true,
                Msg = "Ok"
            };
        }
    }
}*/

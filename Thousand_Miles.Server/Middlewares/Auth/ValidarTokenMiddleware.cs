using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;

namespace Thousand_Miles.Server.Middlewares.Auth
{
    public class ValidarTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public ValidarTokenMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext contexto)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            using (var scope = _serviceProvider.CreateScope())
            {
                if (contexto.Request.Headers.TryGetValue("Authorization", out StringValues authHeader))
                {
                    var token = authHeader.ToString().Replace("Bearer ", "");

                    try
                    {
                        if (!ValidarToken(token, out var jwtToken))
                        {
                            contexto.Response.StatusCode = StatusCodes.Status403Forbidden;
                            resposta.Status = StatusCodes.Status403Forbidden;
                            resposta.Mensagem = "Token inválido.";
                            await contexto.Response.WriteAsJsonAsync(resposta);
                            return;
                        }

                        var idUsuario = jwtToken.Claims.FirstOrDefault()?.Value;
                        contexto.Items["id_usuario"] = idUsuario;
                    }
                    catch (Exception ex)
                    {
                        contexto.Response.StatusCode = StatusCodes.Status403Forbidden;
                        resposta.Status = StatusCodes.Status403Forbidden;
                        resposta.Mensagem = ex.Message;
                        await contexto.Response.WriteAsJsonAsync(resposta);
                        return;
                    }
                }
                else
                {
                    contexto.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    resposta.Status = StatusCodes.Status401Unauthorized;
                    resposta.Mensagem = "Token ausente.";
                    await contexto.Response.WriteAsJsonAsync(resposta);
                    return;
                }

                await _next(contexto);
            }
        }


        private bool ValidarToken(string token, out JwtSecurityToken? jwtToken)
        {
            jwtToken = null;
            try
            {
                var escutadorToken = new JwtSecurityTokenHandler();
                var chave = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? throw new ArgumentNullException());

                escutadorToken.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                    ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                    ValidateLifetime = true
                }, out SecurityToken validatedToken);

                jwtToken = (JwtSecurityToken)validatedToken;
                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                throw new Exception("O token expirou.");
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                throw new Exception("A assinatura do token é inválida.");
            }
        }
    

    }

    public static class ValidarTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidarTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidarTokenMiddleware>();
        }
    }
}

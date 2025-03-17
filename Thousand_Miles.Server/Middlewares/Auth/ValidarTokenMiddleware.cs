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

        public async Task Invoke(HttpContext context)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            using (var scope = _serviceProvider.CreateScope())
            {
                if (context.Request.Headers.TryGetValue("Authorization", out StringValues authHeader))
                {
                    var token = authHeader.ToString().Replace("Bearer ", "");

                    try
                    {
                        if (!ValidarToken(token, out var jwtToken))
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            resposta.Status = StatusCodes.Status403Forbidden;
                            resposta.Mensagem = "Token inválido.";
                            await context.Response.WriteAsJsonAsync(resposta);
                            return;
                        }

                        var idUsuario = jwtToken.Claims.FirstOrDefault()?.Value;
                        context.Items["id_usuario"] = idUsuario;
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        resposta.Status = StatusCodes.Status403Forbidden;
                        resposta.Mensagem = ex.Message;
                        await context.Response.WriteAsJsonAsync(resposta);
                        return;
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    resposta.Status = StatusCodes.Status401Unauthorized;
                    resposta.Mensagem = "Token ausente.";
                    await context.Response.WriteAsJsonAsync(resposta);
                    return;
                }

                await _next(context);
            }
        }


        private bool ValidarToken(string token, out JwtSecurityToken? jwtToken)
        {
            jwtToken = null;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? throw new ArgumentNullException());

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
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
            catch (SecurityTokenInvalidIssuerException)
            {
                throw new Exception("O emissor do token não é válido.");
            }
            catch (SecurityTokenException ex)
            {
                throw new Exception($"Erro na validação do token: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado na validação do token: {ex.Message}");
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

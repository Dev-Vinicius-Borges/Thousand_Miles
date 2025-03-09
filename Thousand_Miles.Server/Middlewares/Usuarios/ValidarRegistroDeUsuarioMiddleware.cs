using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ThousandMiles.Server.Dto.Usuarios;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;
using ThousandMiles.Server.Services.Usuarios;

namespace Thousand_Miles.Server.Middlewares.Usuarios
{
    public class ValidarRegistroDeUsuarioMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        public ValidarRegistroDeUsuarioMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();
            using (var scope = _serviceProvider.CreateScope())
            {
                var usuarioService = scope.ServiceProvider.GetRequiredService<IUsuarioInterface>();
                var streamBody = new StreamReader(context.Request.Body);
                var reqBody = await streamBody.ReadToEndAsync();
                context.Request.Body.Position = 0;

                RegistrarUsuarioDto registrarUsuarioDto = JsonSerializer.Deserialize<RegistrarUsuarioDto>(reqBody);

                RespostaModel<UsuarioModel> usuario = await usuarioService.BuscarUsuarioPorEmail(registrarUsuarioDto.email);

                if (usuario.status == 200)
                {
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>
                    {
                        status = StatusCodes.Status409Conflict,
                        Mensagem = "Tente com outras credenciais."
                    };
                    await context.Response.WriteAsJsonAsync(resposta);
                    return;

                }
                await _next(context);
            }
        }
    }

    public static class ValidarRegistroDeUsuarioMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidarRegistroDeUsuarioMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidarRegistroDeUsuarioMiddleware>();
        }
    }
}

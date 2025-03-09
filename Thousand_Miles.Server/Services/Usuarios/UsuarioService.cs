using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThousandMiles.Server.Database;
using ThousandMiles.Server.Dto.Usuarios;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;

namespace ThousandMiles.Server.Services.Usuarios
{
    public class UsuarioService: IUsuarioInterface
    {
        private readonly IPasswordHasher<UsuarioModel> _passwordHasher;
        private readonly AppDbContext _context;

        public UsuarioService(IPasswordHasher<UsuarioModel> passwordHasher, AppDbContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<RespostaModel<UsuarioModel>> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuarioDto)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.id_usuario == atualizarUsuarioDto.id);

                usuario.email = atualizarUsuarioDto.email;
                usuario.senha = atualizarUsuarioDto.senha;

                await _context.SaveChangesAsync();

                resposta.status = StatusCodes.Status200OK;
                resposta.Mensagem = "Usuário atualizado com sucesso!";

                return resposta;

            }catch(Exception err)
            {
                resposta.status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<UsuarioModel>> BuscarUsuarioPorEmail(string email)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.email == email);

                if (usuario == null)
                {
                    resposta.status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Nenhum usuário encontrado com esse email.";
                    return resposta;
                }

                resposta.status = StatusCodes.Status200OK;
                resposta.Mensagem = "Usuário encontrado";
                resposta.Dados = usuario;

                return resposta;
            }
            catch (Exception err)
            {
                resposta.status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<UsuarioModel>> BuscarUsuarioProId(int id)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.id_usuario == id);

                if(usuario == null)
                {
                    resposta.status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Nenhum usuário encontrado";
                }

                resposta.status = StatusCodes.Status200OK;
                resposta.Dados = usuario;
                resposta.Mensagem = "Usuário encontrado";

                return resposta;
            } catch(Exception err)
            {
                resposta.Mensagem = $"Erro no servidor {err.Message}";
                resposta.status = StatusCodes.Status500InternalServerError;
                return resposta;
            }
        }


        public async Task<RespostaModel<UsuarioModel>> LoginDeUsuario(LoginDeUsuarioDto loginDeUsuarioDto)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.SingleOrDefaultAsync(usuario => usuario.email == loginDeUsuarioDto.email);

                var resultadoMatch = _passwordHasher.VerifyHashedPassword(null, usuario.senha, loginDeUsuarioDto.senha);

                if (resultadoMatch != PasswordVerificationResult.Success)
                {
                    resposta.status = StatusCodes.Status401Unauthorized;
                    resposta.Mensagem = "Senhas não conferem";
                } else
                {
                    Claim[] claims =
                    {
                        new Claim("id", usuario.id_usuario.ToString()),
                        new Claim("email", usuario.email.ToString()),
                    };
                    TokenModel token = new TokenModel(claims);
                    resposta.status = StatusCodes.Status200OK;
                    resposta.Mensagem = "Login realizado com sucesso!";
                    resposta.Token = token.Token;
                }
                return resposta;
            }
            catch (Exception err)
            {
                resposta.status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<UsuarioModel>> RegistrarUsuario(RegistrarUsuarioDto registrarUsuarioDto)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            try
            {
                var novoUsuario = new UsuarioModel()
                {
                    email = registrarUsuarioDto.email,
                    senha = _passwordHasher.HashPassword(null, registrarUsuarioDto.senha),
                    status = true
                };

                _context.Add(novoUsuario);
                await _context.SaveChangesAsync();

                resposta.status = StatusCodes.Status201Created;
                resposta.Dados = await _context.Usuarios.SingleOrDefaultAsync(u => u.email == registrarUsuarioDto.email);
                resposta.Mensagem = "Usuário cadastrado com sucesso!";

                return resposta;

            }catch (Exception err)
            {
                resposta.status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ThousandMiles.Server.Database;
using ThousandMiles.Server.Dto.Usuarios;
using ThousandMiles.Server.Models;
using ThousandMiles.Server.Models.Usuario;

namespace ThousandMiles.Server.Services.Usuarios
{
    public class UsuarioService: IUsuarioInterface
    {
        private readonly IPasswordHasher<UsuarioModel> _passwordHasher;
        private readonly AppDbContext _contexto;

        public UsuarioService(IPasswordHasher<UsuarioModel> passwordHasher, AppDbContext contexto)
        {
            _passwordHasher = passwordHasher;
            _contexto = contexto;
        }

        public async Task<RespostaModel<UsuarioModel>> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuarioDto)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();

            try
            {
                var usuario = await _contexto.Usuarios.SingleOrDefaultAsync(u => u.id_usuario == atualizarUsuarioDto.id);

                if (usuario == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Usuário não encontrado.";
                    return resposta;
                }

                usuario.email = atualizarUsuarioDto.email;
                usuario.senha = atualizarUsuarioDto.senha;

                await _contexto.SaveChangesAsync();

                resposta.Status = StatusCodes.Status200OK;
                resposta.Mensagem = "Usuário atualizado com sucesso!";

                return resposta;

            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<UsuarioModel>> BuscarUsuarioPorEmail(string email)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            try
            {
                var usuario = await _contexto.Usuarios.SingleOrDefaultAsync(u => u.email == email);

                if (usuario == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Nenhum usuário encontrado com esse email.";
                    return resposta;
                }

                resposta.Status = StatusCodes.Status200OK;
                resposta.Mensagem = "Usuário encontrado";
                resposta.Dados = usuario;

                return resposta;
            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<UsuarioModel>> BuscarUsuarioProId(int id)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            try
            {
                var usuario = await _contexto.Usuarios.SingleOrDefaultAsync(u => u.id_usuario == id);

                if(usuario == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Nenhum usuário encontrado";
                }

                resposta.Status = StatusCodes.Status200OK;
                resposta.Dados = usuario;
                resposta.Mensagem = "Usuário encontrado";

                return resposta;
            } catch(Exception err)
            {
                resposta.Mensagem = $"Erro no servidor {err.Message}";
                resposta.Status = StatusCodes.Status500InternalServerError;
                return resposta;
            }
        }

        public async Task<RespostaModel<UsuarioModel>> DesativarConta(int id)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            try
            {
                UsuarioModel? usuario = await _contexto.Usuarios.SingleOrDefaultAsync(u => u.id_usuario == id);

                if (usuario == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Usuário não encontrado.";
                    return resposta;
                }

                usuario.status = false;

                await _contexto.SaveChangesAsync();

                resposta.Status = StatusCodes.Status200OK;
                resposta.Mensagem = "Conta desativada com sucesso.";
                return resposta;

            }catch(Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }

        public async Task<RespostaModel<UsuarioModel>> LoginDeUsuario(LoginDeUsuarioDto loginDeUsuarioDto)
        {
            RespostaModel<UsuarioModel> resposta = new RespostaModel<UsuarioModel>();
            try
            {
                var usuario = await _contexto.Usuarios.SingleOrDefaultAsync(usuario => usuario.email == loginDeUsuarioDto.email);

                if (usuario == null)
                {
                    resposta.Status = StatusCodes.Status404NotFound;
                    resposta.Mensagem = "Usuário não encontrado.";
                    return resposta;
                }

                var resultadoMatch = _passwordHasher.VerifyHashedPassword(usuario, usuario.senha, loginDeUsuarioDto.senha);

                if (resultadoMatch != PasswordVerificationResult.Success)
                {
                    resposta.Status = StatusCodes.Status401Unauthorized;
                    resposta.Mensagem = "Senhas não conferem";
                }
                else
                {
                    Claim[] claims =
                    {
                        new Claim("id", usuario.id_usuario.ToString()),
                        new Claim("email", usuario.email.ToString()),
                    };
                    TokenModel token = new TokenModel(claims, 10);
                    resposta.Status = StatusCodes.Status200OK;
                    resposta.Mensagem = "Login realizado com sucesso!";
                    resposta.Token = token.Token;
                }
                return resposta;
            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
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
                    senha = registrarUsuarioDto.senha,
                    status = true
                };

                novoUsuario.senha = _passwordHasher.HashPassword(novoUsuario, registrarUsuarioDto.senha);

                _contexto.Add(novoUsuario);
                await _contexto.SaveChangesAsync();

                resposta.Status = StatusCodes.Status201Created;
                resposta.Dados = await _contexto.Usuarios.SingleOrDefaultAsync(u => u.email == registrarUsuarioDto.email);
                resposta.Mensagem = "Usuário cadastrado com sucesso!";

                return resposta;

            }
            catch (Exception err)
            {
                resposta.Status = StatusCodes.Status500InternalServerError;
                resposta.Mensagem = $"Erro no servidor: {err.Message}";
                return resposta;
            }
        }
    }
}

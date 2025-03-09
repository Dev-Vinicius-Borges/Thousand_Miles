

using Microsoft.EntityFrameworkCore;
using ThousandMiles.Server.Models.Reservas;
using ThousandMiles.Server.Models.Usuario;
using ThousandMiles.Server.Models.Usuarios;
using ThousandMiles.Server.Models.Veiculo;

namespace ThousandMiles.Server.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //Usuarios
        public DbSet<EstadoModel> Estados { get; set; }

        public DbSet<CidadeModel> Cidades { get; set; }

        public DbSet<BairroModel> Bairros { get; set; }

        public DbSet<EnderecoModel> Enderecos { get; set; }

        public DbSet<TipoDocumentoModel> TipoDocumentos { get; set; }

        public DbSet<DadosPessoaisModel> DadosPessoais { get; set; }
        public DbSet<DocumentoModel> Documentos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<VeiculosFavoritosModel> VeiculosFavoritos { get; set; }


        //Veiculos
        public DbSet<CambioModel> Cambios { get; set; }

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<CombustivelModel> Combustiveis { get; set; }

        public DbSet<CoresModel> Cores { get; set; }

        public DbSet<FotoModeloModel> FotosModelos { get; set; }

        public DbSet<MarcaModel> Marcas { get; set; }

        public DbSet<ModeloModel> Modelos { get; set; }

        public DbSet<VeiculoModel> Veiculos { get; set; }

        //Reservas
        public DbSet<ReservaModel> Reservas { get; set; }

        public DbSet<SeguroModel> Seguros { get; set; }
    }
}

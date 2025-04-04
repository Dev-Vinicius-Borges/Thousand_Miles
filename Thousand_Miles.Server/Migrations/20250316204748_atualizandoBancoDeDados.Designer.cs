﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThousandMiles.Server.Database;

#nullable disable

namespace Thousand_Miles.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250316204748_atualizandoBancoDeDados")]
    partial class atualizandoBancoDeDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ThousandMiles.Server.Models.Reservas.ReservaModel", b =>
                {
                    b.Property<int>("id_reserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_reserva"));

                    b.Property<DateTime>("data_devolucao")
                        .HasColumnType("date");

                    b.Property<DateTime>("data_inicio")
                        .HasColumnType("date");

                    b.Property<float>("preco_total")
                        .HasColumnType("real");

                    b.Property<int?>("seguroId_seguro")
                        .HasColumnType("int");

                    b.Property<int>("usuarioid_usuario")
                        .HasColumnType("int");

                    b.Property<int>("veiculoid_veiculo")
                        .HasColumnType("int");

                    b.HasKey("id_reserva");

                    b.HasIndex("seguroId_seguro");

                    b.HasIndex("usuarioid_usuario");

                    b.HasIndex("veiculoid_veiculo");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Reservas.SeguroModel", b =>
                {
                    b.Property<int>("Id_seguro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_seguro"));

                    b.Property<float>("custo")
                        .HasColumnType("real");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_seguro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_seguro");

                    b.ToTable("Seguros");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.BairroModel", b =>
                {
                    b.Property<int>("id_bairro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_bairro"));

                    b.Property<int>("cidadeid_cidade")
                        .HasColumnType("int");

                    b.Property<string>("nome_bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id_bairro");

                    b.HasIndex("cidadeid_cidade");

                    b.ToTable("Bairros");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.CidadeModel", b =>
                {
                    b.Property<int>("id_cidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_cidade"));

                    b.Property<int>("estadoid_estado")
                        .HasColumnType("int");

                    b.Property<string>("nome_cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id_cidade");

                    b.HasIndex("estadoid_estado");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.DadosPessoaisModel", b =>
                {
                    b.Property<int>("id_dados_pessoais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_dados_pessoais"));

                    b.Property<DateTime>("data_nascimento")
                        .HasColumnType("date");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("id_dados_pessoais");

                    b.ToTable("DadosPessoais");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.DocumentoModel", b =>
                {
                    b.Property<int>("id_documento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_documento"));

                    b.Property<int>("dados_pessoaisid_dados_pessoais")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_emissao")
                        .HasColumnType("date");

                    b.Property<string>("numero_documento")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("tipo_documentoid_tipo_documento")
                        .HasColumnType("int");

                    b.HasKey("id_documento");

                    b.HasIndex("dados_pessoaisid_dados_pessoais");

                    b.HasIndex("tipo_documentoid_tipo_documento");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.EnderecoModel", b =>
                {
                    b.Property<int>("id_endereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_endereco"));

                    b.Property<int>("bairroid_bairro")
                        .HasColumnType("int");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id_endereco");

                    b.HasIndex("bairroid_bairro");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.EstadoModel", b =>
                {
                    b.Property<int>("id_estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_estado"));

                    b.Property<string>("nome_estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("sigla")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.HasKey("id_estado");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.TipoDocumentoModel", b =>
                {
                    b.Property<int>("id_tipo_documento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_tipo_documento"));

                    b.Property<string>("tipo_documento")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("id_tipo_documento");

                    b.ToTable("TipoDocumentos");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.UsuarioModel", b =>
                {
                    b.Property<int>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_usuario"));

                    b.Property<int?>("dados_pessoaisid_dados_pessoais")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("enderecoid_endereco")
                        .HasColumnType("int");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("id_usuario");

                    b.HasIndex("dados_pessoaisid_dados_pessoais");

                    b.HasIndex("enderecoid_endereco");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuarios.VeiculosFavoritosModel", b =>
                {
                    b.Property<int>("id_favoritos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_favoritos"));

                    b.Property<int>("modeloid_modelo")
                        .HasColumnType("int");

                    b.Property<int>("usuarioid_usuario")
                        .HasColumnType("int");

                    b.HasKey("id_favoritos");

                    b.HasIndex("modeloid_modelo");

                    b.HasIndex("usuarioid_usuario");

                    b.ToTable("VeiculosFavoritos");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.CambioModel", b =>
                {
                    b.Property<int>("id_cambio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_cambio"));

                    b.Property<string>("nome_cambio")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("id_cambio");

                    b.ToTable("Cambios");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.CategoriaModel", b =>
                {
                    b.Property<int>("id_categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_categoria"));

                    b.Property<string>("nome_categoria")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id_categoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.CombustivelModel", b =>
                {
                    b.Property<int>("id_combustivel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_combustivel"));

                    b.Property<string>("nome_combustivel")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("id_combustivel");

                    b.ToTable("Combustiveis");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.CoresModel", b =>
                {
                    b.Property<int>("id_cor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_cor"));

                    b.Property<string>("codigo_cor")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("nome_cor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id_cor");

                    b.ToTable("Cores");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.FotoModeloModel", b =>
                {
                    b.Property<int>("id_foto_modelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_foto_modelo"));

                    b.Property<int>("corid_cor")
                        .HasColumnType("int");

                    b.Property<int>("modeloid_modelo")
                        .HasColumnType("int");

                    b.Property<string>("tipo_conteudo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("url_modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_foto_modelo");

                    b.HasIndex("corid_cor");

                    b.HasIndex("modeloid_modelo");

                    b.ToTable("FotosModelos");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.MarcaModel", b =>
                {
                    b.Property<int>("id_marca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_marca"));

                    b.Property<string>("logo_marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome_marca")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("id_marca");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.ModeloModel", b =>
                {
                    b.Property<int>("id_modelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_modelo"));

                    b.Property<byte>("assentos")
                        .HasColumnType("tinyint");

                    b.Property<int>("cambioid_cambio")
                        .HasColumnType("int");

                    b.Property<int>("categoriaid_categoria")
                        .HasColumnType("int");

                    b.Property<int>("combustivelid_combustivel")
                        .HasColumnType("int");

                    b.Property<string>("descricao_modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("marcaid_marca")
                        .HasColumnType("int");

                    b.Property<string>("nome_modelo")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<byte>("portas")
                        .HasColumnType("tinyint");

                    b.HasKey("id_modelo");

                    b.HasIndex("cambioid_cambio");

                    b.HasIndex("categoriaid_categoria");

                    b.HasIndex("combustivelid_combustivel");

                    b.HasIndex("marcaid_marca");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.VeiculoModel", b =>
                {
                    b.Property<int>("id_veiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_veiculo"));

                    b.Property<int>("ano_fabricacao")
                        .HasColumnType("int");

                    b.Property<bool>("disponibilidade")
                        .HasColumnType("bit");

                    b.Property<string>("placa")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.HasKey("id_veiculo");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Reservas.ReservaModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Reservas.SeguroModel", "seguro")
                        .WithMany()
                        .HasForeignKey("seguroId_seguro");

                    b.HasOne("ThousandMiles.Server.Models.Usuario.UsuarioModel", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioid_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThousandMiles.Server.Models.Veiculo.VeiculoModel", "veiculo")
                        .WithMany()
                        .HasForeignKey("veiculoid_veiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("seguro");

                    b.Navigation("usuario");

                    b.Navigation("veiculo");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.BairroModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Usuario.CidadeModel", "cidade")
                        .WithMany()
                        .HasForeignKey("cidadeid_cidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cidade");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.CidadeModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Usuario.EstadoModel", "estado")
                        .WithMany()
                        .HasForeignKey("estadoid_estado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estado");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.DocumentoModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Usuario.DadosPessoaisModel", "dados_pessoais")
                        .WithMany("documentos")
                        .HasForeignKey("dados_pessoaisid_dados_pessoais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThousandMiles.Server.Models.Usuario.TipoDocumentoModel", "tipo_documento")
                        .WithMany()
                        .HasForeignKey("tipo_documentoid_tipo_documento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dados_pessoais");

                    b.Navigation("tipo_documento");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.EnderecoModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Usuario.BairroModel", "bairro")
                        .WithMany()
                        .HasForeignKey("bairroid_bairro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bairro");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.UsuarioModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Usuario.DadosPessoaisModel", "dados_pessoais")
                        .WithMany()
                        .HasForeignKey("dados_pessoaisid_dados_pessoais");

                    b.HasOne("ThousandMiles.Server.Models.Usuario.EnderecoModel", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoid_endereco");

                    b.Navigation("dados_pessoais");

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuarios.VeiculosFavoritosModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Veiculo.ModeloModel", "modelo")
                        .WithMany()
                        .HasForeignKey("modeloid_modelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThousandMiles.Server.Models.Usuario.UsuarioModel", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioid_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("modelo");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.FotoModeloModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Veiculo.CoresModel", "cor")
                        .WithMany()
                        .HasForeignKey("corid_cor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThousandMiles.Server.Models.Veiculo.ModeloModel", "modelo")
                        .WithMany()
                        .HasForeignKey("modeloid_modelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cor");

                    b.Navigation("modelo");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Veiculo.ModeloModel", b =>
                {
                    b.HasOne("ThousandMiles.Server.Models.Veiculo.CambioModel", "cambio")
                        .WithMany()
                        .HasForeignKey("cambioid_cambio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThousandMiles.Server.Models.Veiculo.CategoriaModel", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaid_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThousandMiles.Server.Models.Veiculo.CombustivelModel", "combustivel")
                        .WithMany()
                        .HasForeignKey("combustivelid_combustivel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThousandMiles.Server.Models.Veiculo.MarcaModel", "marca")
                        .WithMany()
                        .HasForeignKey("marcaid_marca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cambio");

                    b.Navigation("categoria");

                    b.Navigation("combustivel");

                    b.Navigation("marca");
                });

            modelBuilder.Entity("ThousandMiles.Server.Models.Usuario.DadosPessoaisModel", b =>
                {
                    b.Navigation("documentos");
                });
#pragma warning restore 612, 618
        }
    }
}

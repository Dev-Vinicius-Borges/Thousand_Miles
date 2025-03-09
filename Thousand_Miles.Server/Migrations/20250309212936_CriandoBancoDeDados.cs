using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thousand_Miles.Server.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cambios",
                columns: table => new
                {
                    id_cambio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cambio = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cambios", x => x.id_cambio);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_categoria = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Combustiveis",
                columns: table => new
                {
                    id_combustivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_combustivel = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustiveis", x => x.id_combustivel);
                });

            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    id_cor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cor = table.Column<string>(type: "varchar(50)", nullable: false),
                    codigo_cor = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.id_cor);
                });

            migrationBuilder.CreateTable(
                name: "DadosPessoais",
                columns: table => new
                {
                    id_dados_pessoais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    sobrenome = table.Column<string>(type: "varchar(100)", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    genero = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPessoais", x => x.id_dados_pessoais);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    sigla = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    id_marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_marca = table.Column<string>(type: "varchar(45)", nullable: false),
                    logo_marca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.id_marca);
                });

            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    id_seguro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_seguro = table.Column<string>(type: "varchar(50)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.id_seguro);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    id_tipo_documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_documento = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.id_tipo_documento);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    id_veiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plaxa = table.Column<string>(type: "varchar(12)", nullable: false),
                    disponibilidade = table.Column<bool>(type: "bit", nullable: false),
                    ano_fabricacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.id_veiculo);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    id_cidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    estadoid_estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.id_cidade);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_estadoid_estado",
                        column: x => x.estadoid_estado,
                        principalTable: "Estados",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    id_modelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_modelo = table.Column<string>(type: "varchar(45)", nullable: false),
                    assentos = table.Column<byte>(type: "tinyint", nullable: false),
                    portas = table.Column<byte>(type: "tinyint", nullable: false),
                    descricao_modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marcaid_marca = table.Column<int>(type: "int", nullable: false),
                    categoriaid_categoria = table.Column<int>(type: "int", nullable: false),
                    cambioid_cambio = table.Column<int>(type: "int", nullable: false),
                    combustivelid_combustivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.id_modelo);
                    table.ForeignKey(
                        name: "FK_Modelos_Cambios_cambioid_cambio",
                        column: x => x.cambioid_cambio,
                        principalTable: "Cambios",
                        principalColumn: "id_cambio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modelos_Categorias_categoriaid_categoria",
                        column: x => x.categoriaid_categoria,
                        principalTable: "Categorias",
                        principalColumn: "id_categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modelos_Combustiveis_combustivelid_combustivel",
                        column: x => x.combustivelid_combustivel,
                        principalTable: "Combustiveis",
                        principalColumn: "id_combustivel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_marcaid_marca",
                        column: x => x.marcaid_marca,
                        principalTable: "Marcas",
                        principalColumn: "id_marca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    id_documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_documento = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_emissao = table.Column<DateTime>(type: "date", nullable: false),
                    tipo_documentoid_tipo_documento = table.Column<int>(type: "int", nullable: false),
                    dados_pessoaisid_dados_pessoais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.id_documento);
                    table.ForeignKey(
                        name: "FK_Documentos_DadosPessoais_dados_pessoaisid_dados_pessoais",
                        column: x => x.dados_pessoaisid_dados_pessoais,
                        principalTable: "DadosPessoais",
                        principalColumn: "id_dados_pessoais",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_TipoDocumentos_tipo_documentoid_tipo_documento",
                        column: x => x.tipo_documentoid_tipo_documento,
                        principalTable: "TipoDocumentos",
                        principalColumn: "id_tipo_documento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bairros",
                columns: table => new
                {
                    id_bairro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    cidadeid_cidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairros", x => x.id_bairro);
                    table.ForeignKey(
                        name: "FK_Bairros_Cidades_cidadeid_cidade",
                        column: x => x.cidadeid_cidade,
                        principalTable: "Cidades",
                        principalColumn: "id_cidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotosModelos",
                columns: table => new
                {
                    id_foto_modelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url_modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_conteudo = table.Column<string>(type: "varchar(50)", nullable: false),
                    corid_cor = table.Column<int>(type: "int", nullable: false),
                    modeloid_modelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosModelos", x => x.id_foto_modelo);
                    table.ForeignKey(
                        name: "FK_FotosModelos_Cores_corid_cor",
                        column: x => x.corid_cor,
                        principalTable: "Cores",
                        principalColumn: "id_cor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FotosModelos_Modelos_modeloid_modelo",
                        column: x => x.modeloid_modelo,
                        principalTable: "Modelos",
                        principalColumn: "id_modelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id_endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rua = table.Column<string>(type: "varchar(50)", nullable: false),
                    numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    cep = table.Column<string>(type: "varchar(11)", nullable: false),
                    bairroid_bairro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id_endereco);
                    table.ForeignKey(
                        name: "FK_Enderecos_Bairros_bairroid_bairro",
                        column: x => x.bairroid_bairro,
                        principalTable: "Bairros",
                        principalColumn: "id_bairro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    dados_pessoaisid_dados_pessoais = table.Column<int>(type: "int", nullable: true),
                    enderecoid_endereco = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_DadosPessoais_dados_pessoaisid_dados_pessoais",
                        column: x => x.dados_pessoaisid_dados_pessoais,
                        principalTable: "DadosPessoais",
                        principalColumn: "id_dados_pessoais");
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_enderecoid_endereco",
                        column: x => x.enderecoid_endereco,
                        principalTable: "Enderecos",
                        principalColumn: "id_endereco");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id_reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    data_devolucao = table.Column<DateTime>(type: "date", nullable: false),
                    preco_total = table.Column<float>(type: "real", nullable: false),
                    seguroid_seguro = table.Column<int>(type: "int", nullable: false),
                    usuarioid_usuario = table.Column<int>(type: "int", nullable: false),
                    veiculoid_veiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.id_reserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Seguros_seguroid_seguro",
                        column: x => x.seguroid_seguro,
                        principalTable: "Seguros",
                        principalColumn: "id_seguro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_usuarioid_usuario",
                        column: x => x.usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Veiculos_veiculoid_veiculo",
                        column: x => x.veiculoid_veiculo,
                        principalTable: "Veiculos",
                        principalColumn: "id_veiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeiculosFavoritos",
                columns: table => new
                {
                    id_favoritos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioid_usuario = table.Column<int>(type: "int", nullable: false),
                    modeloid_modelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculosFavoritos", x => x.id_favoritos);
                    table.ForeignKey(
                        name: "FK_VeiculosFavoritos_Modelos_modeloid_modelo",
                        column: x => x.modeloid_modelo,
                        principalTable: "Modelos",
                        principalColumn: "id_modelo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculosFavoritos_Usuarios_usuarioid_usuario",
                        column: x => x.usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bairros_cidadeid_cidade",
                table: "Bairros",
                column: "cidadeid_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_estadoid_estado",
                table: "Cidades",
                column: "estadoid_estado");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_dados_pessoaisid_dados_pessoais",
                table: "Documentos",
                column: "dados_pessoaisid_dados_pessoais");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_tipo_documentoid_tipo_documento",
                table: "Documentos",
                column: "tipo_documentoid_tipo_documento");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_bairroid_bairro",
                table: "Enderecos",
                column: "bairroid_bairro");

            migrationBuilder.CreateIndex(
                name: "IX_FotosModelos_corid_cor",
                table: "FotosModelos",
                column: "corid_cor");

            migrationBuilder.CreateIndex(
                name: "IX_FotosModelos_modeloid_modelo",
                table: "FotosModelos",
                column: "modeloid_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_cambioid_cambio",
                table: "Modelos",
                column: "cambioid_cambio");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_categoriaid_categoria",
                table: "Modelos",
                column: "categoriaid_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_combustivelid_combustivel",
                table: "Modelos",
                column: "combustivelid_combustivel");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_marcaid_marca",
                table: "Modelos",
                column: "marcaid_marca");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_seguroid_seguro",
                table: "Reservas",
                column: "seguroid_seguro");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_usuarioid_usuario",
                table: "Reservas",
                column: "usuarioid_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_veiculoid_veiculo",
                table: "Reservas",
                column: "veiculoid_veiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_dados_pessoaisid_dados_pessoais",
                table: "Usuarios",
                column: "dados_pessoaisid_dados_pessoais");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_enderecoid_endereco",
                table: "Usuarios",
                column: "enderecoid_endereco");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculosFavoritos_modeloid_modelo",
                table: "VeiculosFavoritos",
                column: "modeloid_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculosFavoritos_usuarioid_usuario",
                table: "VeiculosFavoritos",
                column: "usuarioid_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "FotosModelos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "VeiculosFavoritos");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");

            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "Seguros");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cambios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Combustiveis");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "DadosPessoais");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Bairros");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Usuario
{
    public class DocumentoModel
    {
        [Key]
        public int id_documento { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string numero_documento { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_emissao { get; set; }

        [JsonIgnore]
        public TipoDocumentoModel tipo_documento { get; set; }

        [JsonIgnore]
        public DadosPessoaisModel dados_pessoais { get; set; }
    }
}

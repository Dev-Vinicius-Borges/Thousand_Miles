using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Veiculo
{
    public class MarcaModel
    {
        [Key]
        public int id_marca { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string nome_marca { get; set; }

        public string logo_marca { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Veiculo
{
    public class CombustivelModel
    {
        [Key]
        public int id_combustivel { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string nome_combustivel { get; set; }
    }
}

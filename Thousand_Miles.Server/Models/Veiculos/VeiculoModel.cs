using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Veiculo
{
    public class VeiculoModel
    {
        [Key]
        public int id_veiculo { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string plaxa { get; set; }

        public bool disponibilidade { get; set; }

        public int ano_fabricacao { get; set; }
    }
}

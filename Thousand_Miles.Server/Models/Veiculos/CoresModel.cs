using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Veiculo
{
    public class CoresModel
    {
        [Key]
        public int id_cor { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string nome_cor { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string codigo_cor { get; set; }
    }
}

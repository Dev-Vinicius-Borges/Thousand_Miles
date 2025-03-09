using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Veiculo
{
    public class CategoriaModel
    {
        [Key]
        public int id_categoria { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string nome_categoria { get; set; }
    }
}

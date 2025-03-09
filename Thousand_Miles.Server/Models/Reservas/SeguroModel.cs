using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThousandMiles.Server.Models.Reservas
{
    public class SeguroModel
    {
        [Key]
        public int id_seguro { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string tipo_seguro { get; set; }

        public string descricao { get; set; }

        public float custo { get; set; }
    }
}

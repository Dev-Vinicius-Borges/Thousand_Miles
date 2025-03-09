using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ThousandMiles.Server.Models.Usuario;
using ThousandMiles.Server.Models.Veiculo;

namespace ThousandMiles.Server.Models.Reservas
{
    public class ReservaModel
    {
        [Key]
        public int id_reserva { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_devolucao { get; set; }

        public float preco_total { get; set; }

        [JsonIgnore]
        public SeguroModel seguro { get; set; }

        [JsonIgnore]
        public UsuarioModel usuario { get; set; }

        [JsonIgnore]
        public VeiculoModel veiculo { get; set; }


    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThousandMiles.Server.Models.Usuario
{
    public class DadosPessoaisModel
    {
        [Key]
        public int id_dados_pessoais { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string nome { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string sobrenome { get; set; }

        [Column(TypeName = "date")]
        public DateTime data_nascimento { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string genero { get; set; }

        public ICollection<DocumentoModel> documentos { get; set; }

    }
}

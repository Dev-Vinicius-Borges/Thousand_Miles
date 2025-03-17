﻿using Thousand_Miles.Server.Dto.Bairros;

namespace Thousand_Miles.Server.Dto.Enderecos
{
    public class AtualizarEnderecoDto
    {
        public int id_endereco { get; set; }

        public required string rua { get; set; }

        public required string numero { get; set; }

        public required string cep { get; set; }

        public required AtualizarBairroDto bairro { get; set; }

    }
}

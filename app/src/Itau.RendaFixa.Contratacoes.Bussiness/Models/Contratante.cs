﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Itau.RendaFixa.Contratacoes.Bussiness.Models
{
    public class Contratante
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [Column("segmento")]
        public string Segmento { get; set; }

        [Column("habilitado")]
        public bool Habilitado { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Ativos.API.Model
{
    public class Ativo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Nome { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Modelo { get; set; }

        public string Identificador { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
 
        [Required]
        public DateTime DataUltimaManutencao { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Categoria { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Fornecedor { get; set; }

        public ICollection<Manutencao> Manutencoes { get; set; }

        public int TipoId { get; set; }
        public TipoAtivo Tipo { get; set; }
    }
}

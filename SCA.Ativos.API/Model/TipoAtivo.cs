using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Ativos.API.Model
{
    public class TipoAtivo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Descricao { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Ativos.API.Model
{
    public class Ativo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Identificador { get; set; }
        public string DataCompra { get; set; }
        public string DataCadastro { get; set; }
        public string DataUltimaManutencao { get; set; }
        public string Categoria { get; set; }
        public string Fornecedor { get; set; }
    }
}

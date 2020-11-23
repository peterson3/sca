using System;

namespace SCA.IntegrationEvents.Ativo
{
    public class AtivoAdicionadoEvent
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Modelo { get; set; }

        public string Identificador { get; set; }

        public DateTime DataCompra { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataUltimaManutencao { get; set; }

        public string Categoria { get; set; }

        public string Fornecedor { get; set; }

        public int TipoId { get; set; }
    }
}

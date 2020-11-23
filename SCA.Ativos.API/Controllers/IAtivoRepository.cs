using SCA.Ativos.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCA.Ativos.API.Controllers
{
    public interface IAtivoRepository
    {
        Task<IEnumerable<Ativo>> ObterTodos();
        Task<Ativo> ObterPorId(int id);
        void Adicionar(Ativo ativo);
        Task<IEnumerable<TipoAtivo>> ObterTodosTipos();
        void Alterar(Ativo ativo);
        Task<IEnumerable<Ativo>> ObterComFiltro(string filtro);
        void Remover(int id);
    }
}
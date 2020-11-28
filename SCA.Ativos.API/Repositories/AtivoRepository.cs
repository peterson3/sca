using Microsoft.EntityFrameworkCore;
using SCA.Ativos.API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Ativos.API.Controllers
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly AtivoContext _context;

        public AtivoRepository(AtivoContext context)
        {
            _context = context;
        }

        public void Adicionar(Ativo ativo)
        {
            _context.Ativos.Add(ativo);
            _context.SaveChanges();
        }

        public void Adicionar(Manutencao manutencao)
        {
            _context.Manutencoes.Add(manutencao);
            _context.SaveChanges();
        }

        public void Alterar(Ativo ativo)
        {
            var atv = _context.Ativos
                .Find(ativo.Id);

            _context.Entry(atv).CurrentValues.SetValues(ativo);
             _context.SaveChanges();

        }

        public async Task<IEnumerable<Ativo>> ObterComFiltro(string filtro)
        {
            filtro = filtro.ToLower();

            return await _context.Ativos.Include(a => a.Tipo).Where(
                x=> 
                x.Nome.ToLower().Contains(filtro)
                || x.Categoria.ToLower().Contains(filtro)
                || x.Id.ToString().ToLower().Contains(filtro)
                || x.Modelo.ToLower().Contains(filtro)
                || x.Tipo.Descricao.ToLower().Contains(filtro)
                || x.Identificador.ToLower().Contains(filtro)
                || x.Fornecedor.ToLower().Contains(filtro)
                )
                .ToListAsync();
        }

        public Task<Ativo> ObterPorId(int id)
        {
            var ativo = _context.Ativos
                .Where(x=> x.Id == id)
                .Include(a=> a.Tipo)
                .Include(b=> b.Manutencoes)
                .FirstOrDefault();
            //var manutencaos = ativo.Manutencoes;
            return Task.FromResult(ativo);

        }

        public async Task<IEnumerable<Ativo>> ObterTodos()
        {
            return await _context.Ativos.Include(b => b.Manutencoes).Include(t=> t.Tipo).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TipoAtivo>> ObterTodosTipos()
        {
            return await _context.TipoAtivos.AsNoTracking().ToListAsync();
        }

        public void Remover(int id)
        {
            var atv = _context.Ativos
                .Find(id);

            _context.Entry(atv).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
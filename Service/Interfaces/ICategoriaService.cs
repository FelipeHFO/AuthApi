using Domain.Entities;

namespace Service.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObterTodosAsync();
        Task<Categoria> ObterPorIdAsync(int id);
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Categoria categoria);
        Task<bool> RemoverAsync(int id);
    }
}

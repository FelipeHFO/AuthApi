using Domain.Entities;
using Domain.Constants;
using Service.Interfaces;
using Repository.Interfaces;

namespace Service.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepository<Categoria> _repository;

        public CategoriaService(IRepository<Categoria> categoriaRepository)
        {
            _repository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ObterTodosAsync()
        {
            var categorias = await _repository.ObterTodosAsync();

            if (categorias == null || !categorias.Any())
            {
                return new List<Categoria>();
            }

            return categorias;
        }

        public async Task<Categoria> ObterPorIdAsync(int id)
        {
            var categoria = await _repository.ObterPorIdAsync(id);

            if (categoria == null)
            {
                throw new KeyNotFoundException(MensagensErro.EntidadeNaoEncontrada);
            }

            return categoria;
        }

        public async Task<Categoria> AdicionarAsync(Categoria categoria)
        {
            return await _repository.AdicionarAsync(categoria);
        }

        public async Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            var existente = await _repository.ObterPorIdAsync(categoria.Id);

            if (existente == null)
            {
                throw new KeyNotFoundException(MensagensErro.EntidadeNaoEncontrada);
            }

            return await _repository.AtualizarAsync(categoria);
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var categoria = await _repository.ObterPorIdAsync(id);

            if (categoria == null)
            {
                throw new KeyNotFoundException(MensagensErro.EntidadeNaoEncontrada);
            }

            return await _repository.RemoverAsync(id);
        }
    }
}

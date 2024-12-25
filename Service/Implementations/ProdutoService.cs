using Domain.Constants;
using Domain.Entities;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepository<Produto> _repository;

        public ProdutoService(IRepository<Produto> produtoRepository)
        {
            _repository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            var produtos = await _repository.ObterTodosAsync();

            if (produtos == null || !produtos.Any())
            {
                return new List<Produto>();
            }

            return produtos;
        }

        public async Task<Produto> ObterPorIdAsync(int id)
        {
            var produto = await _repository.ObterPorIdAsync(id);

            if (produto == null)
            {
                throw new KeyNotFoundException(MensagensErro.EntidadeNaoEncontrada);
            }

            return produto;
        }

        public async Task<Produto> AdicionarAsync(Produto produto)
        {
            return await _repository.AdicionarAsync(produto);
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            var existente = await _repository.ObterPorIdAsync(produto.Id);

            if (existente == null)
            {
                throw new KeyNotFoundException(MensagensErro.EntidadeNaoEncontrada);
            }

            return await _repository.AtualizarAsync(produto);
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var produto = await _repository.ObterPorIdAsync(id);

            if (produto == null)
            {
                throw new KeyNotFoundException(MensagensErro.EntidadeNaoEncontrada);
            }

            return await _repository.RemoverAsync(id);
        }
    }
}

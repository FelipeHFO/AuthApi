namespace Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }

        #region "Colunas de Auditoria"

        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }

        #endregion

        #region "Relacionamentos"

        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; } // Navegação para Categoria
        #endregion
    }
}

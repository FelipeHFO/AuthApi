namespace Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }

        #region "Colunas de Auditoria"

        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }

        #endregion

        #region "Relacionamentos"

        public IEnumerable<Produto> Produtos { get; set; } // Relacionamento de um para muitos com Produto

        #endregion
    }
}

namespace Financas.Domain.Models
{
    /// <summary>
    /// Modelo de entidade para a Classe Categoria
    /// </summary>
    public class Categoria
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public List<Guid>? ListaDeContas {  get; set; }
    }
}

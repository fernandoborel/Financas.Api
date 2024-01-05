namespace Financas.Domain.Models
{
    /// <summary>
    /// Modelo de entidade para a Classe Conta
    /// </summary>
    public class Conta
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Descricao { get; set; }
        public int? Valor {  get; set; }
        public DateTime? DataDePagamento { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}

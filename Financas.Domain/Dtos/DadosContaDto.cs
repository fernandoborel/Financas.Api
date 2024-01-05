namespace Financas.Domain.Dtos
{
    /// <summary>
    /// DTO para retornar dados de consulta de Conta
    /// </summary>
    public class DadosContaDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Login { get; set;}
        public string? Email { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}

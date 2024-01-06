namespace Financas.Domain.Dtos
{
    /// <summary>
    /// Dto para retornar os dados da categoria
    /// </summary>
    public class DadosCategoriaDto
    {
        public Guid? Id { get; set; }
        public string? Descricao { get; set; }
        public DadosContaDto? Autor { get; set; }
    }
}

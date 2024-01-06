using System.ComponentModel.DataAnnotations;

namespace Financas.Domain.Dtos
{
    /// <summary>
    /// Dto para capturar os dados de categoria
    /// </summary>
    public class CriarCategoriaDto
    {
        [Required(ErrorMessage = "Informe a descrição da categoria.")]
        public string? Descricao { get; set; }
    }
}

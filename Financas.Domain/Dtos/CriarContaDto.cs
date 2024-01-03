using System.ComponentModel.DataAnnotations;

namespace Financas.Domain.Dtos
{
    /// <summary>
    /// DTO para capturar os dados de cadastro de pessoa
    /// </summary>
    public class CriarContaDto
    {
        [LengthAttribute(8, 20, ErrorMessage = "O Nome da conta deve ter entre {1} e {2} caracteres.")]
        [Required(ErrorMessage = "Informe o nome da conta")]
        public string? Nome { get; set; }

        [LengthAttribute(8, 100, ErrorMessage = "O Nome da conta deve ter entre {1} e {2} caracteres.")]
        [Required(ErrorMessage = "Informe o descrição da conta")]
        public string? Descricao { get; set; }
    }
}

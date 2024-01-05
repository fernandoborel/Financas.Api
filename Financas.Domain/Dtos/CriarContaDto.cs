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

        [Required(ErrorMessage = "Informe o login.")]
        public string? Login { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o endereço de email.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-_=+[\]{}|;:'<>,.?/]).{8,}$",
            ErrorMessage = "Informe a senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
        [Required(ErrorMessage = "Informe a senha de acesso.")]
        public string? Senha { get; set; }

        [LengthAttribute(8, 100, ErrorMessage = "O Nome da conta deve ter entre {1} e {2} caracteres.")]
        [Required(ErrorMessage = "Informe o descrição da conta")]
        public string? Descricao { get; set; }
    }
}

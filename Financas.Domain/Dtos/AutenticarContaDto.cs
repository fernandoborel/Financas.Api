using System.ComponentModel.DataAnnotations;

namespace Financas.Domain.Dtos
{
    /// <summary>
    /// DTO para capturar os dados de autenticação
    /// </summary>
    public class AutenticarContaDto
    {
        [Required(ErrorMessage = "Informe um Login válido!")]
        public string? Login {  get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-_=+[\]{}|;:'<>,.?/]).{8,}$",
           ErrorMessage = "Informe a senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
        [Required(ErrorMessage = "Informe a senha de acesso.")]
        public string? Senha { get; set; }
    }
}

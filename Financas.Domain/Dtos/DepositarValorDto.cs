using System.ComponentModel.DataAnnotations;

namespace Financas.Domain.Dtos
{
    public class DepositarValorDto
    {
        [Required(ErrorMessage = "Digite o valor que deseja depositar.")]
        public int DepositarValor { get; set; }
    }
}

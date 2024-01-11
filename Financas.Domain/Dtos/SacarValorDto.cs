using System.ComponentModel.DataAnnotations;

namespace Financas.Domain.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class SacarValorDto
    {
        [Required(ErrorMessage = "Digite o valor que deseja sacar.")]
        public int SacarValor {  get; set; }
    }
}

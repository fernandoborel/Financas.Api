using System;

namespace Financas.Domain.Models
{
    /// <summary>
    /// Classe de entidade para operações de conta
    /// </summary>
    public class OperacoesConta
    {
        public Guid Id { get; set; }
        public int Sacar { get; set; }
        public int Depositar { get; set; }
        public int Saldo { get; set; }
    }
}

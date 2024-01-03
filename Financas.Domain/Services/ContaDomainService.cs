using Financas.Domain.Dtos;
using Financas.Domain.Interfaces.Repositories;
using Financas.Domain.Interfaces.Services;
using Financas.Domain.Models;

namespace Financas.Domain.Services
{
    /// <summary>
    /// Classe para implementar os serviços de domínio de Conta
    /// </summary>
    public class ContaDomainService : IContaDomainService
    {
        //atributo
        private readonly IContaRepository _contaRepository;

        //construtor
        public ContaDomainService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<Guid> Criar(CriarContaDto dto)
        {
            //objeto
            var conta = new Conta
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                DataDePagamento = DateTime.Now,
                Valor = null
            };

            //gravando..
            await _contaRepository.AddAsync(conta);

            //id
            return conta.Id.Value;
        }
    }
}

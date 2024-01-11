using Financas.Domain.Dtos;
using Financas.Domain.Interfaces.Repositories;
using Financas.Domain.Interfaces.Services;
using MongoDB.Bson;

namespace Financas.Domain.Services
{
    public class OperacoesDomainService : IOperacoesDomainService
    {
        private readonly IOperacoesContaRepository _operacoesContaRepository;

        public OperacoesDomainService(IOperacoesContaRepository operacoesContaRepository)
        {
            _operacoesContaRepository = operacoesContaRepository;
        }

        public async Task<int> ConsultarValor()
        {
            try
            {
                // Lógica para consultar o saldo no repositório
                var saldo = await _operacoesContaRepository.ConsultarSaldo();
                return saldo;
            }
            catch (Exception ex)
            {
                // Trate exceções conforme necessário
                throw new ApplicationException("Erro ao consultar o saldo.", ex);
            }
        }

        public async Task<Guid> Depositar(DepositarValorDto dto)
        {
            try
            {
                // Lógica para depositar no repositório
                var objectId = Guid.NewGuid();

                // Altere a assinatura do método Depositar no repositório para aceitar um Guid como segundo parâmetro
                var id = await _operacoesContaRepository.Depositar(dto.DepositarValor, objectId);

                return id; // Não é necessário converter para string e depois novamente para Guid
            }
            catch (Exception ex)
            {
                // Trate exceções conforme necessário
                throw new ApplicationException("Erro ao depositar.", ex);
            }
        }


        public async Task<Guid> Sacar(SacarValorDto dto)
        {
            //try
            //{
            //    // Lógica para sacar no repositório
            //    var objectId = ObjectId.GenerateNewId().ToString();

            //    var idString = await _operacoesContaRepository.Sacar(dto.SacarValor);

            //    if (Guid.TryParse(idString, out Guid id))
            //    {
            //        return id;
            //    }
            //    else
            //    {
            //        // Lógica para lidar com o caso em que a conversão falha
            //        throw new InvalidOperationException("Erro ao converter o ID para Guid.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Trate exceções conforme necessário
            //    throw new ApplicationException("Erro ao sacar.", ex);
            //}
            throw new NotImplementedException();
        }

    }
}

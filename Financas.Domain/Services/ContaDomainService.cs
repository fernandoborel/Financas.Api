using Financas.Domain.Dtos;
using Financas.Domain.Helpers;
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
            #region Não permitir o mesmo login

            if (await _contaRepository.GetAsync(dto.Login) != null)
                throw new ApplicationException("O login informado já esta cadastrado!");

            #endregion


            //objeto
            var conta = new Conta
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Login = dto.Login,
                Senha = Sha1CryptoHelper.Create(dto.Senha),
                Descricao = dto.Descricao,
                DataDePagamento = DateTime.Now,
                DataCadastro = DateTime.Now,
                Valor = null
            };

            //gravando..
            await _contaRepository.AddAsync(conta);

            //id
            return conta.Id.Value;
        }

        public async Task<DadosContaDto> Autenticar(AutenticarContaDto dto)
        {
            var pessoa = await _contaRepository.GetAsync(dto.Login, Sha1CryptoHelper.Create(dto.Senha));

            #region Acesso Negado

            if (pessoa == null)
                throw new ApplicationException("Acesso negado! Conta não encontrada!");

            #endregion

            //retornando os dados..
            var result = new DadosContaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Login = pessoa.Login,
                Email = pessoa.Email,
                DataCadastro = pessoa.DataCadastro
            };

            return result;
        }
    }
}

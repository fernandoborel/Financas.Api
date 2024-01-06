using Financas.Domain.Dtos;
using Financas.Domain.Interfaces.Repositories;
using Financas.Domain.Interfaces.Services;
using Financas.Domain.Models;

namespace Financas.Domain.Services
{
    /// <summary>
    /// Classe para implementar os serviços de dominio de Categoria
    /// </summary>
    public class CategoriaDomainService : ICategoriaDomainService
    {
        private readonly ICategoriaRepository? _categoriaRepository;

        public CategoriaDomainService(ICategoriaRepository? categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Guid> Criar(CriarCategoriaDto dto, Guid autorId)
        {
            var categoria = new Categoria
            {
                Id = Guid.NewGuid(),
                Descricao = dto.Descricao,
                AutorId = autorId,
            };

            await _categoriaRepository.AddAsync(categoria);

            return categoria.Id.Value;
        }

        public async Task<List<DadosCategoriaDto>> Consultar()
        {
            return await _categoriaRepository.GetAllAsync();
        }
    }
}

using Financas.Domain.Dtos;
using Financas.Domain.Interfaces.Repositories;
using Financas.Domain.Models;
using MongoDB.Driver;

namespace Financas.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para Categoria
    /// </summary>
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly IMongoCollection<Categoria> _categoriaCollection;

        //construtor
        public CategoriaRepository(IMongoDatabase database) : base(database) 
        {
            _categoriaCollection = database.GetCollection<Categoria>("Categoria");
        }

        public async Task<List<DadosCategoriaDto>> GetAllAsync()
        {
            var cursor = await Collection.FindAsync(Builders<Categoria>.Filter.Empty);
            var categorias = await cursor.ToListAsync();

            var dadosCategoriaDtoList = new List<DadosCategoriaDto>();

            foreach (var categoria in categorias)
            {
                // garantir que não retorne null
                if (categoria.AutorId != null)
                {
                    var contaCategoria = await _categoriaCollection
                        .Find(c => c.Id == categoria.AutorId)
                        .FirstOrDefaultAsync();

                    var dadosCategoriaDto = new DadosCategoriaDto
                    {
                        Id = categoria.Id,
                        Descricao = categoria.Descricao,
                        Autor = contaCategoria != null
                            ? new DadosContaDto
                            {
                                Id = contaCategoria.Id,
                                Nome = contaCategoria.Nome,
                            }
                            : null
                    };

                    dadosCategoriaDtoList.Add(dadosCategoriaDto);
                }
            }

            return dadosCategoriaDtoList
                .OrderByDescending(d => d.Autor?.Nome) // Ordenar por Nome do Autor
                .ToList();
        }
    }
}

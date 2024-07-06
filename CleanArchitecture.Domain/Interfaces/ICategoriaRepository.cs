using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> ObterTodosAsync();
    Task<Categoria> ObterPorIdAsync(int? id);
    Task<Categoria> AdicionarAsync(Categoria categoria);
    Task<Categoria> AtualizarAsync(Categoria categoria);
    Task<Categoria> RemoverAsync(Categoria categoria);
}

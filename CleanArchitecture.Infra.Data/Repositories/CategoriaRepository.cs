using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ApplicationDbContext _context;

    public CategoriaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categoria>> ObterTodosAsync()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<Categoria> ObterPorIdAsync(int? id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<Categoria> AdicionarAsync(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> AtualizarAsync(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> RemoverAsync(Categoria categoria)
    {
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }
}

using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> AdicionarAsync(Produto produto)
    {
        _context.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> ObterPorIdAsync(int? id)
    {
        return await _context.Produtos.Include(c => c.Categoria)
           .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> RemoverAsync(Produto produto)
    {
        _context.Remove(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> AtualizarAsync(Produto produto)
    {
        _context.Update(produto);
        await _context.SaveChangesAsync();
        return produto;
    }
}

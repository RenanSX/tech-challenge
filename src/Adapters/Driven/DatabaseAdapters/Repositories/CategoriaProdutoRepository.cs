using System;
using System.Threading.Tasks;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class CategoriaProdutoRepository : ICategoriaProdutoRepository
  {
    private readonly DatabaseContext _dbContext;

    public CategoriaProdutoRepository(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<CategoriaProduto>> GetAll()
    {
      return await _dbContext.CategoriaProdutos.AsNoTracking().ToListAsync();
    }
    public async Task<CategoriaProduto> GetById(int id)
    {
      return await _dbContext.CategoriaProdutos.FindAsync(id);
    }
    public void Add(CategoriaProduto CategoriaProduto)
    {
      _dbContext.CategoriaProdutos.Add(CategoriaProduto);
    }
    public void Update(CategoriaProduto CategoriaProduto)
    {
      _dbContext.CategoriaProdutos.Update(CategoriaProduto);
    }
  }
}
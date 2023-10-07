using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class PedidoRepository : IPedidoRepository
  {
    private readonly DatabaseContext _dbContext;

    public PedidoRepository(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Pedido>> GetAll()
    {
      return await _dbContext.Pedidos.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Pedido>> GetByStatus(Status status)
    {
      return await _dbContext.Pedidos.AsNoTracking().Include(p => p.Status).Where(s => s.Status == status).ToListAsync();
    }

    public async Task<IEnumerable<Pedido>> GetByCliente(Cliente cliente)
    {
      return await _dbContext.Pedidos.AsNoTracking().Include(p => p.Cliente).Where(c => c.Cliente == cliente).ToListAsync();
    }

    public async Task<Pedido> GetById(Guid id)
    {
      return await _dbContext.Pedidos.FindAsync(id);
    }

    public void Add(Pedido Pedido)
    {
      _dbContext.Pedidos.Add(Pedido);
      _dbContext.SaveChanges();
    }
    public void UpdateStatus(Pedido pedido)
    {
      _dbContext.Pedidos.Update(pedido);
      _dbContext.SaveChanges();
    }
  }
}
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DatabaseAdapters.Repositories;

public class UsuarioCategory : IUsuarioRepository
{
  private readonly DatabaseContext _dbContext;

  public UsuarioCategory(DatabaseContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<Usuario?> GetByLoginAndPassword(string login, string password)
  {
    return await _dbContext.Usuarios.FirstOrDefaultAsync(p => p.Login == login && p.Senha == password);
  }

  public void Add(Usuario Usuario)
  {
    _dbContext.Usuarios.Add(Usuario);
    _dbContext.SaveChanges();
  }

  public void Update(Usuario Usuario)
  {
    _dbContext.Usuarios.Update(Usuario);
    _dbContext.SaveChanges();
  }
}
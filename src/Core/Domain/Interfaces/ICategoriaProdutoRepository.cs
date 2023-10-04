using System;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
  public interface ICategoriaProdutoRepository
  {
    Task<IEnumerable<CategoriaProduto>> GetAll();
    Task<CategoriaProduto> GetById(int id);

    void Add(CategoriaProduto categoria);
    void Update(CategoriaProduto categoria);
  }
}
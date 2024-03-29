namespace ControladorPedidos.App.Entities.Repositories;

public interface IProdutoRepository
{
  Task<IEnumerable<Produto>> GetAll();
  Task<Produto?> GetById(Guid id);
  Task<IEnumerable<Produto>> GetByCategoria(Guid categoriaId);
  Task Add(Produto produto);
  void UpdateProduct(Produto produto);
  void Add(CategoriaProduto categoria);
  void Update(CategoriaProduto categoria);
  void Remove(Produto produto);
}
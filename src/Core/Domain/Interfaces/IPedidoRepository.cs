using System;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
  public interface IPedidoRepository
  {
    Task<IEnumerable<Pedido>> GetAll();
    Task<IEnumerable<Pedido>> GetByStatus(Status status);
    Task<IEnumerable<Pedido>> GetByCliente(Cliente cliente);
    Task<Pedido> GetById(int id);

    void UpdateStatus(Pedido pedido);
    void Add(Pedido pedido);
  }
}
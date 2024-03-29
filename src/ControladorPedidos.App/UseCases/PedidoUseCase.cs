using ControladorPedidos.App.Contracts;
using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Exceptions;
using ControladorPedidos.App.Entities.Repositories;
using ControladorPedidos.App.Entities.Shared;
using ControladorPedidos.App.Entities.Validators;

namespace ControladorPedidos.App.UseCases;

public class PedidoUseCase(IPedidoRepository pedidoRepository, ILogger<PedidoUseCase> logger,
    IProdutoRepository produtoRepository, IClienteRepository clienteRepository) : IPedidoUseCase
{
    public async Task AlterarStatusPedido(Guid id, Status novoStatus)
    {
        try
        {
            logger.LogInformation("Alterando status do pedido {id} para {status}", id, novoStatus.ToString());

            var pedido = await pedidoRepository.GetById(id) ?? throw new NotFoundException("Pedido não encontrado");
            Status statusAtual = pedido.Status;
            if (novoStatus < statusAtual)
                throw new BusinessException("Não é possível alterar o status do pedido para um status inferior ao atual");
            if (novoStatus == statusAtual)
                throw new BusinessException("Não é possível alterar o status do pedido para o mesmo status atual");
            if (novoStatus > statusAtual + 1)
                throw new BusinessException("Não é possível alterar o status do pedido para um status superior ao atual + 1");

            pedido.Status = novoStatus;

            await pedidoRepository.UpdateStatus(pedido);

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao alterar status do pedido {id} para {status}", id, novoStatus.ToString());
            throw;
        }
    }

    public async Task<IEnumerable<Pedido?>> TodosPedidos()
    {
        logger.LogInformation("Buscando todos os pedidos");

        try
        {
            var pedidos = await pedidoRepository.GetAll();
            var pedidosOrdenados = OrdenarPedidos(pedidos!);

            return pedidosOrdenados.Any() ? pedidosOrdenados : throw new NotFoundException("Pedidos não encontrados");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao buscar todos os pedidos.");
            throw;
        }
    }

    public IEnumerable<Pedido> OrdenarPedidos(IEnumerable<Pedido> pedidos)
    {
        return pedidos
        .Where(x => x.Status != Status.Finalizado)
        .OrderByDescending(x => x.Status)
        .ThenBy(x => x.CriadoEm);
    }

    public async Task MontarPedido(Pedido pedido)
    {
        logger.LogInformation("Criando pedido");

        _ = await clienteRepository.GetById((Guid)pedido.ClienteId!) ?? throw new NotFoundException("Cliente não encontrado");

        var produtoIds = pedido.Produtos.Select(p => p.Id);

        pedido.Produtos = new List<Produto>();

        foreach (var p in produtoIds)
        {
            var produto = await produtoRepository.GetById(p) ?? throw new NotFoundException("Produto não encontrado");
            pedido.Produtos.Add(produto);
        }

        try
        {
            if (PedidoValidador.IsValid(pedido)) await pedidoRepository.Add(pedido);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao criar pedido");
            throw;
        }
    }
}

using ControladorPedidos.App.Contracts;
using ControladorPedidos.App.Entities;
using ControladorPedidos.App.Entities.Exceptions;
using ControladorPedidos.App.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControladorPedidos.App.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaProdutoController(ILogger<CategoriaProdutoController> logger, ICategoriaProdutoUseCase categoriaUseCase) : ControllerBase
{
    /// <summary>
    /// Listar categorias de produto
    /// </summary>
    /// <returns>Retorna lista de categorias de produtos</returns>
    /// <response code="200">Retorno da lista de produto(s) consultado(s).</response>
    /// <response code="400">Erro ao fazer a Request.</response>
    /// <response code="500">Erro Interno.</response>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        logger.LogInformation("Listando categorias de produto");
        try
        {
            var categorias = await categoriaUseCase.TodasCategorias();
            return Ok(categorias);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Listando categorias de produto");
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
    }

    /// <summary>
    /// Criar uma categoria de produto
    /// </summary>
    /// <param name="categoria">Dados da nova categoria produto</param>
    /// <returns>Retorna ID nova categoria produto.</returns>
    /// <response code="201">Categoria criada com sucesso</response>
    /// <response code="500">Erro Interno.</response>
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CriarCategoriaProdutoDto categoria)
    {
        try
        {
            CategoriaProduto categoriaProduto = (CategoriaProduto)categoria;
            await categoriaUseCase.CriarCategoriaAsync(categoriaProduto);
            return Created($"/CategoriaProduto/{categoriaProduto.Id}", new { id = categoriaProduto.Id });
        }

        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno");
        }
    }
}
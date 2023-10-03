using APISimplesMongoDB.Models;
using APISimplesMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISimplesMongoDB.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoServices _produtoServices;

    public ProdutosController(ProdutoServices produtoServices)
    {
        _produtoServices = produtoServices;  
    }

    [HttpGet]
    public async Task<List<Produto>> GetProdutos()
        => await _produtoServices.GetAllAsync();


    [HttpGet("{id}")]
    public async Task<Produto> Get(string id)
    {
        try
        {
            var produto = await _produtoServices.GetAsync(id);
            return produto;

        }
        catch (Exception ex)
        {

            throw new Exception ("Produto não localizado !", ex);
        }
    }

    [HttpPost]
    public async Task<Produto> PostProduto(Produto produto)
    {
        await _produtoServices.CreateAsync(produto);

        return produto;
    }

    [HttpPut]
    public async Task<Produto> PutProduto(string id, Produto produto)
    {
        try
        {
            var prod = await _produtoServices.GetAsync(id);
            await _produtoServices.UpdateAsync(id, produto);

            return produto;
        }
        catch (Exception ex)
        {

            throw new Exception("Produto não localizado !", ex);
        }
    }

    [HttpDelete]
    public async Task<Produto> DeleteProduto(string id)
    {
        try
        {
            var produto = await _produtoServices.GetAsync(id);
            await _produtoServices.RemoveAsync(id);

            return produto;
        }
        catch (Exception ex)
        {

            throw new Exception("Produto não localizado !", ex);
        }
    }
}
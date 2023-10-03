using APISimplesMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APISimplesMongoDB.Services;

public class ProdutoServices
{
    private readonly IMongoCollection<Produto> _produtoCollection;

    public ProdutoServices(IOptions<ProdutoDatabaseSettings> produtoServices)
    {
        var mongoClient = new MongoClient(produtoServices.Value.ConnectionString);
        var mondoDatabase = mongoClient.GetDatabase(produtoServices.Value.DatabaseName);

        _produtoCollection = mondoDatabase.GetCollection<Produto>
                            (produtoServices.Value.ProdutoCollectionName);
    }

    public async Task<List<Produto>> GetAllAsync() =>
        await _produtoCollection.Find(x => true).ToListAsync();

    public async Task<Produto> GetAsync(string id) =>
        await _produtoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Produto produto) =>
        await _produtoCollection.InsertOneAsync(produto);

    public async Task UpdateAsync(string id, Produto produto) =>
        await _produtoCollection.ReplaceOneAsync(x=> x.Id == id, produto);

    public async Task RemoveAsync(string id) =>
        await _produtoCollection.DeleteOneAsync(x=> x.Id == id);
}

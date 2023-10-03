using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APISimplesMongoDB.Models;

[BsonIgnoreExtraElements]
public class Produto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("categoria")]
    public string? Categoria  { get; set; }
    [BsonElement("nome")]
    public string? Nome { get; set; }
    [BsonElement("preco")]
    public float Preco { get; set; }
    [BsonElement("ativo")]
    public bool Ativo { get; set; }
}

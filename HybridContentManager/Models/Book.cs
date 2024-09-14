using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HybridContentManager.Models;

public class Book
{
    [BsonId]  
    [BsonRepresentation(BsonType.Int32)]  
  
    public int Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("author")]
    public string Author { get; set; }

    [BsonElement("publishedDate")]
    public DateTime PublishedDate { get; set; }

}
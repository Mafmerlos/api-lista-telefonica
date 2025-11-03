using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lista_telefonica_api.Models
{
    public class Contato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nome")]
        public string Nome { get; set; }
        [BsonElement("telefone")]
        public string Telefone {  get; set; }
        [BsonElement("email")]
        public string Email {  get; set; }
        [BsonElement("enderecos")]
        public List<string> Enderecos { get; set; }
    }
}
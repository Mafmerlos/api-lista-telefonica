using lista_telefonica_api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace lista_telefonica_api.Services
{
    public class ContatoService
    {
        private readonly IMongoCollection<Models.Contato> _colecaoContatos;

        public ContatoService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ListaTelefonicaDB"].ConnectionString;
            var mongoClient = new MongoClient(connectionString);

            var mongoDatabase = mongoClient.GetDatabase("ListaTelefonicaDB");

            _colecaoContatos = mongoDatabase.GetCollection<Contato>("Contatos");
        }

        public async Task<List<Contato>> GetAsync() =>
        await _colecaoContatos.Find(_ => true).ToListAsync();

        public async Task<Contato> GetAsync(string id) =>
            await _colecaoContatos.Find(item => item.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Contato novoContato) =>
            await _colecaoContatos.InsertOneAsync(novoContato);

        public async Task UpdateAsync(string id, Contato contatoAtualizado) =>
            await _colecaoContatos.ReplaceOneAsync(item => item.Id == id, contatoAtualizado);

        public async Task RemoveAsync(string id) =>
            await _colecaoContatos.DeleteOneAsync(item => item.Id == id);








    }



}
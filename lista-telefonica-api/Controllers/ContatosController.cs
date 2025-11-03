using lista_telefonica_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace lista_telefonica_api.Controllers
{
    public class ContatosController : ApiController
    {
        private static List<Contato> listaContatos = new List<Contato>();
        private static int contador = 0;
        // GET: api/Contatos
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(listaContatos);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
           
        }

        // GET: api/Contatos/5
        public IHttpActionResult Get(int id)
        {
            
            try
            {
                var contato = listaContatos.FirstOrDefault(item => item.Id == id);
                return Ok(contato);
            }
            catch (Exception e)
            { 
                return InternalServerError(e);  
            }
        }

        // POST: api/Contatos
        public IHttpActionResult Post([FromBody] Models.Contato value)
        {
            try
            {
                value.Id = ++contador;
                listaContatos.Add(value);
                return Ok();
            }
            catch (Exception e) 
            {
                return InternalServerError(e);
            }

        }

        // PUT: api/Contatos/5
        public IHttpActionResult Put(int id, [FromBody]Models.Contato value)
        {
            if(value.Id == id)
            {
                BadRequest("O id da requisição é diferente do id do corpo da mensagem");
            }
            try
            {
                var contato = listaContatos.FirstOrDefault(item => item.Id == id);
                contato.Nome = value.Nome;
                contato.Telefone = value.Telefone;
                contato.Email = value.Email;
                return Ok();


            }catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        // DELETE: api/Contatos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var contato = listaContatos.FirstOrDefault(item => item.Id == id);
                listaContatos.Remove(contato);
                return Ok("Contato removido");

            }catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}

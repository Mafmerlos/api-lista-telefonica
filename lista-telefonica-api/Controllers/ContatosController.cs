using lista_telefonica_api.Models;
using System;
using lista_telefonica_api.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using System.Threading.Tasks;


namespace lista_telefonica_api.Controllers
{
    [RoutePrefix("api/Contatos")]
    public class ContatosController : ApiController
    {
        private readonly ContatoService _contatoService = new ContatoService();



        // GET: api/Contatos
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var contatos = await _contatoService.GetAsync();
                return Ok(contatos);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
           
        }

        // GET: api/Contatos/5
        [HttpGet]
        [Route("{id:length(24)}")]
        public async Task<IHttpActionResult> Get(string id)
        {

            try
            {
                var contato = await _contatoService.GetAsync(id);
                if (contato == null)
                {
                    return NotFound();
                }
                return Ok(contato);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // POST: api/Contatos
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] Models.Contato novoContato)
        {
            try
            {
              if(novoContato == null)
                {
                    return BadRequest("Adicione um contato válido");
                }
              await _contatoService.CreateAsync(novoContato);
                return Ok(novoContato);
            }
            catch (Exception e) 
            {
                return InternalServerError(e);
            }

        }

        // PUT: api/Contatos/5
        [HttpPut]
        [Route("{id:length(24)}")]
        public async Task<IHttpActionResult> Put(string id, [FromBody]Models.Contato contatoAtualizado)
        {
            try
            {
                var contatoExistente = await _contatoService.GetAsync(id);
                if (contatoExistente == null)
                {
                    return NotFound();
                }

                
                contatoAtualizado.Id = id;

             
                await _contatoService.UpdateAsync(id, contatoAtualizado);

                return Ok(contatoAtualizado); 
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // DELETE: api/Contatos/5
        [HttpDelete]
        [Route("{id:length(24)}")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            try
            {
                var contato = await _contatoService.GetAsync(id);
                if (contato == null)
                {
                    return NotFound();
                }

                // Chama o método do seu serviço
                await _contatoService.RemoveAsync(id);

                // Mantém seu retorno original. Simples e funcional.
                return Ok("Contato removido");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}

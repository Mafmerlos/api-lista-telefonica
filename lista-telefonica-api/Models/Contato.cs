using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lista_telefonica_api.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone {  get; set; }
        public string Email {  get; set; }
        public IEnumerable<Contato> Enderecos { get; set; }
    }
}
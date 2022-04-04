using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Repositorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class EnderecoRepositorio : BaseRepository<Endereco>
    {

        public List<Endereco> listaEnderecos(int id)
        {
            List<Endereco> listaEnderecos = null;
            using (LoremIpsumDBContext db = new LoremIpsumDBContext())
            {
                listaEnderecos = db.enderecos.Where(p => p.idCliente == id).ToList();
            }
            return listaEnderecos;
        }

        public Endereco maxIDEndereco()
        {
            Endereco EnderecoID = null;
            using (LoremIpsumDBContext db = new LoremIpsumDBContext())
            {
                EnderecoID = db.enderecos.OrderByDescending(p => p.Id).FirstOrDefault();
            }
            return EnderecoID;
        }

        public void excluirtodosEnderecos(int id)
        {

            using (LoremIpsumDBContext db = new LoremIpsumDBContext())
            {
                var lista = db.enderecos.Where(p => p.idCliente == id).ToList();
                foreach (var item in lista)
                {
                    db.Entry(item).State = EntityState.Deleted;
                }
                db.SaveChanges();
            }

        }
    }
}

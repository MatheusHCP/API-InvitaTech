using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Repositorio
{
    public class ClienteRepositorio : BaseRepository<Cliente>
    {

        public List<Cliente> getClientes(String descricao)
        {
            List<Cliente> lista = null;
            using (LoremIpsumDBContext db = new LoremIpsumDBContext())
            {
                lista = (db.clientes.Where(p => p.nome.Contains(descricao)).OrderBy(p => p.nome)).ToList();
            }

            return lista;
        }

    }
}

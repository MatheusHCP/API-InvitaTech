using System;
using Entidades;

namespace Repositorio.Models

{
    public class ClienteModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public char sexo { get; set; }
        public EnderecoModel EnderecoModel { get; set; }

    }
}

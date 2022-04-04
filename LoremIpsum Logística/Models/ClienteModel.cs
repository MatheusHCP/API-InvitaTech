using System;
using Entidades;
using System.Collections.Generic;

namespace LoremIpsum_Logística.Models

{
    public class ClienteModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string dataNascimento { get; set; }
        public char sexo { get; set; }
        public List<EnderecoModel> ClienteEnderecos
        {
            get; set;
        }

    }
}

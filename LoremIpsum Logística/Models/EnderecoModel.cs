namespace LoremIpsum_Logística.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public int idCliente { get; set; }
        public string tipoEndereco { get; set; }
        public string CEP { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string UF { get; set; }
    }
}

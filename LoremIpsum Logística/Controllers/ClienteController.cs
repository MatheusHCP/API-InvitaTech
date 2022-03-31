using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using Repositorio;
using LoremIpsum_Logística.Models;
using AutoMapper;

namespace LoremIpsum_Logística.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private void apagarEnderecos(int id)
        {
            new EnderecoRepositorio().excluirtodosEnderecos(id);
        }

        [HttpPost]
        public retorno<ClienteModel> cadastrarCliente(ClienteModel model)
        {
            retorno<ClienteModel> ret = new retorno<ClienteModel>();
            try
            {
                if (model.nome == "" || char.IsWhiteSpace(model.sexo))
                {
                    ret.status = false;
                    ret.mensagem = "Necessário preenchimentos de todos os campos do cadastro do cliente.";

                }
                else
                {
                    ClienteRepositorio cliRep = new ClienteRepositorio();
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    Cliente cli = mapper.Map<Cliente>(model);
                    cliRep.add(cli);
                    model.id = cli.id;
                    //cadastrar enderecos
                    Endereco cliEndereco;
                    foreach (var item in model.ClienteEnderecos)
                    {
                        cliEndereco = new Endereco()
                        {
                            Id = 0,
                            idCliente = model.id,
                            tipoEndereco = char.Parse(item.tipoEndereco),
                            CEP = item.CEP,
                            logradouro = item.logradouro,
                            numero = item.numero,
                            complemento = item.complemento,
                            bairro = item.bairro,
                            cidade = item.cidade,
                            UF = item.UF

                        };
                        (new EnderecoRepositorio()).add(cliEndereco);
                    }
                    // fim cadasto endereco
                    ret.status = true;
                    ret.resultado = model;
                    ret.mensagem = "Cliente cadastrado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.mensagem = "Erro ao cadastrar cliente, verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }


        [HttpPut]
        public retorno<ClienteModel> alterarCliente(ClienteModel model)
        {
            retorno<ClienteModel> ret = new retorno<ClienteModel>();

            try
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                Cliente cli = mapper.Map<Cliente>(model);
                ClienteRepositorio cliRep = new ClienteRepositorio();
                cliRep.edit(cli);
                model.id = cli.id;

                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Cliente alterado com sucesso!";
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.mensagem = "erro ao alterar cliente, verifique os dados técnicos: " + ex;
            }
            return ret;
        }

        [HttpDelete]
        public retorno<ClienteModel> apagarCliente(int id)
        {
            retorno<ClienteModel> ret = new retorno<ClienteModel>();
            try
            {
                ClienteRepositorio cliRep = new ClienteRepositorio();
                Cliente cli = cliRep.get(id);

                if (cli == null)
                {
                    ret.status = false;
                    ret.mensagem = "Cliente não foi localizado.";
                }
                else
                {
                    apagarEnderecos(id);
                    cliRep.delete(cli);
                    ret.status = true;
                    ret.mensagem = "Cliente e seus respectivos endereços excluidos com sucesso!";
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.mensagem = "Tivemos um problema para apagar o cliente, verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }

        [HttpGet]
        public retorno<List<ClienteModel>> allProdutos(string descricao)
        {
            retorno<List<ClienteModel>> lista = new retorno<List<ClienteModel>>();
            try
            {
                if (descricao != null)
                {
                    ClienteRepositorio cliRep = new ClienteRepositorio();
                    List<Cliente> listaClientes = cliRep.getClientes(descricao); // Busca de produtos pela descrição.
                    lista.status = true;
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    lista.resultado = mapper.Map<List<ClienteModel>>(listaClientes);
                    if (listaClientes.Count == 0)
                    {
                        lista.mensagem = "Nenhum cliente localizado.";
                    }
                    else
                    {
                        lista.mensagem = "Busca de clientes realizada com sucesso!";
                    }

                }
                else
                {
                    ClienteRepositorio cliRep = new ClienteRepositorio();
                    List<Cliente> listaProd = cliRep.getAll(); // Busca total em caso de não ter informado nada na descrição.
                    lista.status = true;
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    lista.resultado = mapper.Map<List<ClienteModel>>(listaProd);
                    lista.mensagem = "Lista de todos clientes cadastrados.";
                }
            }
            catch (Exception ex)
            {
                lista.status = false;
                lista.mensagem = "Ocorreu ao listar clientes, verifique os dados técnicos: " + ex;
            }

            return lista;
        }

    }
}

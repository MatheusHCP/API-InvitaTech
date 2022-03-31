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
    public class EnderecoController : ControllerBase
    {

        [HttpPost]
        public retorno<EnderecoModel> CadastrarEndereco(EnderecoModel model)
        {
            retorno<EnderecoModel> ret = new retorno<EnderecoModel>();
            try
            {
                EnderecoRepositorio endRep = new EnderecoRepositorio();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                Endereco end = mapper.Map<Endereco>(model);
                endRep.add(end);
                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Endereço cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.mensagem = "Erro ao cadastrar endereço, verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }


        [HttpPut]
        public retorno<EnderecoModel> alterarEndereco(EnderecoModel model)
        {
            retorno<EnderecoModel> ret = new retorno<EnderecoModel>();

            try
            {
                EnderecoRepositorio endRep = new EnderecoRepositorio();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                Endereco end = mapper.Map<Endereco>(model);
                endRep.edit(end);
                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Endereço alterado com sucesso!";
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.mensagem = "erro ao alterar cliente, verifique os dados técnicos: " + ex;
            }
            return ret;
        }

        [HttpDelete]
        public retorno<ClienteModel> apagarEndereco(int idendereco)
        {
            retorno<ClienteModel> ret = new retorno<ClienteModel>();
            try
            {
                EnderecoRepositorio endRep = new EnderecoRepositorio();
                Endereco end = endRep.get(idendereco);
                endRep.delete(end);
                ret.status=true;
                ret.mensagem = "Endereço apagado com sucesso!";

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
        public retorno<List<EnderecoModel>> allEnderecosCliente(int idCliente)
        {
            retorno<List<EnderecoModel>> lista = new retorno<List<EnderecoModel>>();
            try
            {
                
                EnderecoRepositorio endRep = new EnderecoRepositorio();
                List<Endereco> listaEnderecos = endRep.listaEnderecos(idCliente); // Busca total em caso de não ter informado nada na descrição.
                lista.status = true;
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                lista.resultado = mapper.Map<List<EnderecoModel>>(listaEnderecos);
                if(listaEnderecos.Count == 0)
                {
                    lista.mensagem = "Cliente não possui endereços cadastrados.";
                }
                else
                {
                    lista.mensagem = "Enderecos do cliente encontrado com sucesso!";
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


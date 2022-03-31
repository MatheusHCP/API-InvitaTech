using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoremIpsum_Logística.Models;
using Entidades;

namespace LoremIpsum_Logística
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()

        {

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Cliente, ClienteModel>();
                cfg.CreateMap<ClienteModel, Cliente>();

                cfg.CreateMap<Endereco, EnderecoModel>();
                cfg.CreateMap<EnderecoModel, Endereco>();

            });
            return config;

        }
    }
}

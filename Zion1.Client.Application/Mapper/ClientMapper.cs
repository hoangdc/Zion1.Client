using AutoMapper;
using Zion1.Client.Application.Commands.CreateClient;
using Zion1.Client.Application.Commands.UpdateClient;
using Zion1.Client.Domain.Entities;
using Zion1.Common.Application.Mapper;

namespace Zion1.Client.Application.Mapper
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientInfo, CreateClientRequest>().ReverseMap();
            CreateMap<ClientInfo, UpdateClientRequest>().ReverseMap();
        }
    }

    public class ClientMapper : CommonMapper<ClientMappingProfile>
    {

    }
}

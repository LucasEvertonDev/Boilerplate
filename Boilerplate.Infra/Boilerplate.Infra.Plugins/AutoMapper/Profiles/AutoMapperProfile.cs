using AutoMapper;
using Boilerplate.Core.Domain.Entities;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.Models.Models.Clients.Base;

namespace Boilerplate.Infra.Plugins.AutoMapper.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        ConvertDomainToModel();

        ConvertModelToDomain();
    }


    public void ConvertDomainToModel()
    {
        CreateMap<Client, ClientModel>();
    }

    public void ConvertModelToDomain()
    {
        CreateMap<UpdateClientsModel, Client>();
        CreateMap<CreateClientsModel, Client>();
        CreateMap<ClientModel, Client>();
    }
}

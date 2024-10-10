using AutoMapper;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.ViewModel;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioModel, UsuarioVisualizacaoVM>();

        CreateMap<UsuarioCadastroVM, UsuarioModel>()
            .ForMember(dest => dest.Role, opt => opt.Ignore()); // Ignora Role no mapeamento
    }
}

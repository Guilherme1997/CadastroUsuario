using AutoMapper;

namespace CadastroUsuario.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings() 
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DomainToViewModelProfile());
            });

            var mapper = config.CreateMapper();
        }
    }
}
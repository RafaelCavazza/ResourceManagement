using AutoMapper;

namespace Presentation.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg=> 
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}

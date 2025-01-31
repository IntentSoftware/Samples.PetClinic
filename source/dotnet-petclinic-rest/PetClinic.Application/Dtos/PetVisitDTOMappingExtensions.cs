using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using PetClinic.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace PetClinic.Application.Dtos
{
    public static class PetVisitDTOMappingExtensions
    {
        public static PetVisitDTO MapToPetVisitDTO(this Visit projectFrom, IMapper mapper)
            => mapper.Map<PetVisitDTO>(projectFrom);

        public static List<PetVisitDTO> MapToPetVisitDTOList(this IEnumerable<Visit> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToPetVisitDTO(mapper)).ToList();
    }
}
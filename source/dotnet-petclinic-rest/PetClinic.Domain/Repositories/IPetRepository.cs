using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using PetClinic.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace PetClinic.Domain.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IPetRepository : IEFRepository<Pet, Pet>
    {
        [IntentManaged(Mode.Fully)]
        Task<Pet> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Pet>> FindByIdsAsync(int[] ids, CancellationToken cancellationToken = default);
    }
}
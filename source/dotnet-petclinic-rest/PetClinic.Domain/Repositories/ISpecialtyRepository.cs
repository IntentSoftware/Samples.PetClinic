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
    public interface ISpecialtyRepository : IEFRepository<Specialty, Specialty>
    {
        [IntentManaged(Mode.Fully)]
        Task<Specialty> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Specialty>> FindByIdsAsync(int[] ids, CancellationToken cancellationToken = default);
    }
}
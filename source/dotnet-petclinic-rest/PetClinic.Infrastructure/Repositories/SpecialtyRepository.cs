using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using PetClinic.Domain.Entities;
using PetClinic.Domain.Repositories;
using PetClinic.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace PetClinic.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class SpecialtyRepository : RepositoryBase<Specialty, Specialty, ApplicationDbContext>, ISpecialtyRepository
    {
        [IntentManaged(Mode.Ignore, Signature = Mode.Fully)]
        public SpecialtyRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


        [IntentManaged(Mode.Fully)]
        public async Task<Specialty> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }


        [IntentManaged(Mode.Fully)]
        public async Task<List<Specialty>> FindByIdsAsync(int[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using PetClinic.Application.Dtos;
using PetClinic.Application.Interfaces;
using PetClinic.Domain.Common.Exceptions;
using PetClinic.Domain.Entities;
using PetClinic.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.Application.ServiceImplementations.ServiceImplementation", Version = "1.0")]

namespace PetClinic.Application.Implementation
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public async Task<List<OwnerDTO>> GetOwners(CancellationToken cancellationToken = default)
        {
            var elements = await _ownerRepository.FindAllAsync();
            return elements.MapToOwnerDTOList(_mapper);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public async Task AddOwner(OwnerCreateDTO dto, CancellationToken cancellationToken = default)
        {
            var newOwner = new Owner
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                City = dto.City,
                Telephone = dto.Telephone,
            };

            _ownerRepository.Add(newOwner);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public async Task<OwnerDTO> GetOwner(int ownerId, CancellationToken cancellationToken = default)
        {
            var element = await _ownerRepository.FindByIdAsync(ownerId);
            return element.MapToOwnerDTO(_mapper);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public async Task UpdateOwner(int ownerId, OwnerUpdateDTO dto, CancellationToken cancellationToken = default)
        {
            var existingOwner = await _ownerRepository.FindByIdAsync(ownerId);
            existingOwner.FirstName = dto.FirstName;
            existingOwner.LastName = dto.LastName;
            existingOwner.Address = dto.Address;
            existingOwner.City = dto.City;
            existingOwner.Telephone = dto.Telephone;
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public async Task DeleteOwner(int ownerId, CancellationToken cancellationToken = default)
        {
            var existingOwner = await _ownerRepository.FindByIdAsync(ownerId);
            _ownerRepository.Remove(existingOwner);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public async Task<List<OwnerDTO>> GetOwnersList(string lastName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException("Write your implementation for this service here...");
        }

        public void Dispose()
        {
        }
    }
}
using System.Collections.Generic;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();

        Owner GetOwnerById(int id);

        void DeleteOwner(int ownerId);

        void UpdateOwner(Owner owner);

        void AddOwner(Owner owner);

    }
}

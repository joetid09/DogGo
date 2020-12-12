using System.Collections.Generic;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();

        Owner GetOwnerById(int id);

        public void DeleteOwner(int ownerId);

        public void UpdateOwner(Owner owner);

        public void AddOwner(Owner owner);

    }
}

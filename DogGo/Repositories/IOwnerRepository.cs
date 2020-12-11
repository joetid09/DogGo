using System.Collections.Generic;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();

        Owner GetOwnerById(int id);

        public void DeleteOwner();

        public void UpdateOwner();

        public void AddOwner();

    }
}

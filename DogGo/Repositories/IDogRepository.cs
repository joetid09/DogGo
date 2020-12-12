using System.Collections.Generic;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        void AddDog(Dog dog);
    }
}

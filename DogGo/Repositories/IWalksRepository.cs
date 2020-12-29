using DogGo.Models;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IWalksRepository
    {
        void AddWalk(Walks walk);
        List<Walks> GetWalksByWalker(int id);
        void UpdateWalk(Walks walk);
       Walks GetWalkById(int id);
    }
}
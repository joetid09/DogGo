using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGo.Repositories;
using DogGo.Models;
using DogGo.Models.ViewModels;
using System.Security.Claims;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalksRepository _walksRepo;
        private readonly IOwnerRepository _ownerRepo;
        private readonly INeighborhoodRepository _neighborhoodRepo;

        public WalkersController(IWalkerRepository WalkerRepository, IWalksRepository WalksRepository, IOwnerRepository ownerRepository, INeighborhoodRepository neighborhoodRepository)
        {
            _walkerRepo = WalkerRepository;
            _walksRepo = WalksRepository;
            _ownerRepo = ownerRepository;
            _neighborhoodRepo = neighborhoodRepository;
        }
        // GET: WalkersController
        //sets action of Index() so that when it is call in StartUp.cs it will show list of walkers
        public ActionResult Index()
        {
            
            {

                int id = GetCurrentOwner();
                Owner owner = _ownerRepo.GetOwnerById(id);
                List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);
                Neighborhood neighborhood = _neighborhoodRepo.GetNeighborhoodById(owner.NeighborhoodId);

                LocalWalkerListViewModel vm = new LocalWalkerListViewModel
                {
                    Walker = walkers,
                    Neighborhood = neighborhood
                };

                return View(vm);
            } else
            {   
                return 
            }
        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);

            List<Walks> walks = _walksRepo.GetWalksByWalker(id);

            WalkerProfileViewModel vm = new WalkerProfileViewModel
            {
                Walker = walker,
                Walks = walks
            };

            if (walker == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public int GetCurrentOwner()
        {
            int id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return id;
        }
    }
}

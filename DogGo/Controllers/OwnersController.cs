using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGo.Repositories;
using DogGo.Models;
using DogGo.Models.ViewModels;
using System;

namespace DogGo.Controllers
{
    public class OwnersController : Controller
    {
        private IOwnerRepository _ownerRepo;
        private IDogRepository _dogRepo;
        private IWalkerRepository _walkerRepo;
        private INeighborhoodRepository _neighborhoodRepo;
        public OwnersController(IOwnerRepository ownerRepo, IDogRepository dogRepo, IWalkerRepository walkerRepo, INeighborhoodRepository neighborhoodRepo)
        {
            _ownerRepo = ownerRepo;
            _dogRepo = dogRepo;
            _walkerRepo = walkerRepo;
            _neighborhoodRepo = neighborhoodRepo;
        }
        // GET: OwnerController1
        public ActionResult Index()
        {
            List<Owner> owners = _ownerRepo.GetAllOwners();
            return View(owners);
        }

        // GET: OwnerController1/Details/5
        public ActionResult Details(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);
            List < Dog > dogs = _dogRepo.GetDogsByOwnerId(id);
            List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);

            ProfileViewModel vm = new ProfileViewModel()
            {
                Owner = owner,
                Dogs = dogs,
                Walkers = walkers
            };

            if(owner  == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: OwnerController1/Create
        public ActionResult Create()
        {
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();

            OwnerFormViewModel vm = new OwnerFormViewModel()
            {
                Owner = new Owner(),
                Neighborhood = neighborhoods
            };
            return View(vm);
        }

        // POST: OwnerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                _ownerRepo.AddOwner(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(owner);
            }
        }

        // GET: OwnerController1/Edit/5
        public ActionResult Edit(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();

            OwnerFormViewModel vm = new OwnerFormViewModel()
            {
                Owner = owner,
                Neighborhood = neighborhoods
            };
            return View(vm);
        }

        // POST: OwnerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Owner owner)
        {
            try
            {
                _ownerRepo.UpdateOwner(owner);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(owner);
                
            }
        }

        // GET: OwnerController1/Delete/5
        public ActionResult Delete(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);
            return View(owner);
        }

        // POST: OwnerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Owner owner)
        {
            try
            {
                _ownerRepo.DeleteOwner(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(owner);
            }
        }
    }
}

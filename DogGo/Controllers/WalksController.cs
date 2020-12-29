using DogGo.Repositories;
using DogGo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGo.Models.ViewModels;
using System.Security.Claims;
using System;

namespace DogGo.Controllers
{
    
    public class WalksController : Controller
    {
        private readonly IWalkerRepository _walkerRepository;
        private readonly IWalksRepository _walksRepository;
        private readonly IDogRepository _dogRepository;

        public WalksController(IWalksRepository walksRepository, IWalkerRepository walkerRepository, IDogRepository dogRepository)
        {
            _walkerRepository = walkerRepository;
            _walksRepository = walksRepository;
            _dogRepository = dogRepository;
        }
        // GET: WalksController
        public ActionResult Index()
        {

            return View();
        }

        // GET: WalksController/Details/5
        public ActionResult Details(int id)
        {
                        return View();
        }

        // GET: WalksController/Create
        public ActionResult Create(int id)
        {
            Walker walker = _walkerRepository.GetWalkerById(id);
            int ownerId = GetCurrentOwner();
            List<Dog> dogs = _dogRepository.GetDogsByOwnerId(ownerId);

            AppointmentViewModel avm = new AppointmentViewModel
            {
                OwnerId = ownerId,
                Walker = walker,
                Doggos = dogs
            };
            return View(avm);
        }

        // POST: WalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentViewModel avm, int id)
        {
            try
            {
                _walksRepository.AddWalk(avm.Walk);
                return RedirectToAction("Details", "Owners");
            }
            catch(Exception ex)
            {
                Walker walker = _walkerRepository.GetWalkerById(id);
                int ownerId = GetCurrentOwner();
                List<Dog> dogs = _dogRepository.GetDogsByOwnerId(ownerId);

                avm = new AppointmentViewModel
                {
                    OwnerId = ownerId,
                    Walker = walker,
                    Doggos = dogs,
                    ErrorMessage = "Oh no, seems something is wrong. Please ensure the form is filled out completely"
                };
                return View(avm);
            }
        }

        // GET: WalksController/Edit/5
        public ActionResult Edit(int id)
        {
            Walks walk = _walksRepository.GetWalkById(id);
            
            return View(walk);
        }

        // POST: WalksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Walks walk)
        {

            try
            {
                _walksRepository.UpdateWalk(walk);
                return RedirectToAction("Details", "Walkers");
            }
            catch
            {
                return View();
            }
        }

        // GET: WalksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalksController/Delete/5
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

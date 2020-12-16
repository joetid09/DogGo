using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DogGo.Repositories;
using DogGo.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DogGo.Controllers
{
    public class DogController : Controller
    {

        private readonly IDogRepository _dogRepo;

        public DogController(IDogRepository DogRepository)
            {
            _dogRepo = DogRepository;
            }
        // GET: DogController
        //added a new helper method called GetCurrentUserID which get the userId from the claims/cookies made in authentication step on ownerController
        //[Authorize] requires someone to be logged in before be able to see that particular 
        [Authorize]
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Dog> dogs = _dogRepo.GetDogsByOwnerId(ownerId);
            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
                return View(dog);
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Dog dog)
        {
            try
            {
                dog.OwnerId = GetCurrentUserId();
                _dogRepo.AddDog(dog);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
            int currentUserId = GetCurrentUserId();
            if (dog.OwnerId == currentUserId)
            {
                return View(dog);
            }
            return NotFound();
        }
                    
                    

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            int currentUserId = GetCurrentUserId();
            if (dog.OwnerId == currentUserId)
            {
                try
                {
                    _dogRepo.UpdateDog(dog);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(dog);
                }
            }
            return NotFound();
        }

        // GET: DogController/Delete/5
        public ActionResult Delete(int id)
         
        {
            int currentUserId = GetCurrentUserId();
            Dog dog = _dogRepo.GetDogById(id);
            if(dog.OwnerId == currentUserId)
            {
                return View(dog);
            }

            return NotFound();
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            int currentUserId = GetCurrentUserId();
            if (dog.OwnerId == currentUserId)
                try
            {
                _dogRepo.DeleteDog(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(dog);
            }
            return NotFound();
        }

        //goes into the cookies/claims maded during loging/auth, takes the string value from the xml, converts back to int, and returns it
        public int GetCurrentUserId()
        {
            int id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return id;
        }

    }
}

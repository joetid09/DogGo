using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGo.Repositories;
using DogGo.Models;
using DogGo.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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

        //Login action for doggo info

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            Walker walker = _walkerRepo.GetWalkerByEmail(viewModel.Email);

            if(walker == null)
            {
                return Unauthorized();
            }

            List<Claim> claims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, walker.Id.ToString()),
               new Claim(ClaimTypes.Email, walker.Email),
               new Claim(ClaimTypes.Role, "Walker")
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Dogs");
        }
        // GET: WalkersController
        //sets action of Index() so that when it is call in StartUp.cs it will show list of walkers
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                int id = GetCurrentOwner();
                Owner owner = _ownerRepo.GetOwnerById(id);
                List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);
                List<Neighborhood> neighborhood = _neighborhoodRepo.GetNeighborhoodsById(owner.NeighborhoodId);

                LocalWalkerListViewModel vm = new LocalWalkerListViewModel
                {
                    Walker = walkers,
                    Neighborhoods = neighborhood
                };

                return View(vm);
            } else
            {
               List<Walker> walkers = _walkerRepo.GetAllWalkers();
               List<Neighborhood> neighborhood = _neighborhoodRepo.GetAll();

                LocalWalkerListViewModel vm = new LocalWalkerListViewModel
                {
                    Walker = walkers,
                    Neighborhoods = neighborhood
                };
                return View(vm);
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

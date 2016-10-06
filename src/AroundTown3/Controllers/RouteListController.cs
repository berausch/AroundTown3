using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AroundTown3.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AroundTown3.Controllers
{
    [Authorize]
    public class RouteListController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public RouteListController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute(string newRouteName)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Route newRoute = new Route(newRouteName);
            newRoute.User = currentUser;
            _db.Routes.Add(newRoute);
            _db.SaveChanges();
            return Json(newRoute);
        }


        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Routes.Where(x => x.User.Id == currentUser.Id));
        }

        public IActionResult RouteDetails(int id)
        {
            var thisRoute = _db.Routes.FirstOrDefault(routes => routes.Id == id);
            if (thisRoute.Locations == null)
            {
                return RedirectToAction("CreateLocation");
            }
            else
            {
                return View(thisRoute.Locations.ToList());
            }
        }

        public IActionResult CreateLocationStart()
        {
            return View();
        }

        public IActionResult CreateLocationEnd()
        {
            return View();
        }

        public IActionResult CreateLocation()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Route route)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            route.User = currentUser;
            _db.Routes.Add(route);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

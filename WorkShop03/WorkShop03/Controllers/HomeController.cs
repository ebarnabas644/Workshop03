using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkShop03.Data;
using WorkShop03.Models;

namespace WorkShop03.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ILogger<HomeController> _logger;

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _db;

        public HomeController(UserManager<User> userManager, ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            this.userManager = userManager;
            _logger = logger;
            this.roleManager = roleManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var pri = this.User;
            var user = await userManager.GetUserAsync(pri);
            if (user != null)
            {
                return View(_db.Advertisements.Where(x => x.Pay >= user.MinimumPay));
            }

            return View(_db.Advertisements);


        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Advertisement ad)
        {
            var old = _db.Advertisements.FirstOrDefault(x => x.Name == ad.Name && x.Position == ad.Position && x.Description == ad.Description);
            if (old == null)
            {
                _db.Advertisements.Add(ad);
                _db.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string id)
        {
            var pri = this.User;
            var user = await userManager.GetUserAsync(pri);
            if (user != null)
            {
                var ad = _db.Advertisements.FirstOrDefault(x => x.Uid == id);

                if (ad != null)
                {
                    ad.Subscribed.Add(user);
                }
            }
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> DelegateAdmin()
        {
            var pri = this.User;
            var user = await userManager.GetUserAsync(pri);

            var role = new IdentityRole()
            {
                Name = "Admin"
            };

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(role);
            }

            await userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
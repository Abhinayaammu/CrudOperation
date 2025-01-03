using System.Diagnostics;
using CrudOp.Models;
using Microsoft.AspNetCore.Mvc;
using OperationCrud.Data;
using OperationCrud.Models;

namespace CrudOp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _Context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _Context = context;
        }

        public IActionResult Index()
        {
            List<User> userList = _Context.users.ToList();
            return View(userList);
            
        }

        public IActionResult Details( int id)
        {
            return View(_Context.users.FirstOrDefault(x => x.Id == id));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {

            try
            {
                _Context.users.Add(user);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {
            return View(_Context.users.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {

            try
            {
                _Context.users.Add(user);
                _Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
           
        }

        public IActionResult Delete(int id)
        {

            User user = _Context.users.Where(t => t.Id == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {

            try
            {
                User user = _Context.users.Where(t => t.Id == id).FirstOrDefault();

                //if(employee != null && employee.Id>0)

                if (user?.Id > 0)
                {
                    _Context.users.Remove(user);
                    _Context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sfcf.Domain.Abstract;
using sfcf.Domain.Entities;

namespace sfcf.WebUI.Controllers
{
    public class CategoryNavController : Controller
    {
        private IRepository repository;
        public CategoryNavController(IRepository repo)
        {
            repository = repo;
        }
        // GET: CategoryNav
        public PartialViewResult Menu()
        {
            IEnumerable<Category> categories = repository.Categories.OrderBy(c => c.Name);

            return PartialView(categories);
        }
    }
}
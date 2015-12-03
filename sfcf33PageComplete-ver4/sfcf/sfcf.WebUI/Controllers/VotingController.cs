using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using sfcf.Domain.Abstract;
using sfcf.Domain.Entities;
using sfcf.WebUI.ViewModels;
using sfcf.Domain.Concrete;

namespace sfcf.WebUI.Controllers
{
    public class VotingController : Controller
    {
        private IRepository repository;
        public int pageSize = 2;

        public VotingController(IRepository efRepository)
        {
            this.repository = efRepository;
        }

        

        public ViewResult List(int? categoryId, int? page)
        {
            /*
            VotingListData viewModel = new VotingListData();

            viewModel.Votings = repository.Votings
                .Include(i => i.Category)
                .Include(i => i.Options)
                .OrderBy(v => v.Title);
            */

            
            int pageNumber = (page ?? 1);
            

            VotingListData model = new VotingListData
            {
                Votings = repository.Votings
                .Where(v => categoryId == null || v.CategoryID == categoryId)
                .Include(i => i.Category)
                .Include(i => i.Options)
                .OrderBy(v => v.Title)
                .ToPagedList(pageNumber, pageSize),

                Categories = repository.Categories,
                CurrentCategoryId = categoryId
            };

                       

            return View(model);

            /*
            return View(repository.Votings.OrderBy(v => v.Title).ToPagedList(pageNumber, pageSize));
             */
        }
    }
}
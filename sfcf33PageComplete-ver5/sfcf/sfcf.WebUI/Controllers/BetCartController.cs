using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sfcf.Domain.Entities;
using sfcf.Domain.NotDbEntities;
using sfcf.Domain.Abstract;
using sfcf.WebUI.ViewModels;

namespace sfcf.WebUI.Controllers
{
    public class BetCartController : Controller
    {
        private IRepository repository;
        public BetCartController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(BetCart betCart, string returnUrl)
        {
            return View(new CartIndexData
            {
                BetCart = betCart,
                ReturnUrl = returnUrl,
                nullBetMessage = "На интерес"
            });
        }

        public PartialViewResult Summary(BetCart betCart)
        {
            return PartialView(betCart);
        }

        public RedirectToRouteResult AddToBetCart(BetCart betCart, int optionId, int? size, string returnUrl)
        {
            Option option = repository.Options.FirstOrDefault(op => op.ID == optionId);

            if (option != null)
            {
                betCart.AddBetDraft(option, size);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromBetCart(BetCart betCart, int optionId, string returnUrl)
        {
            Option option = repository.Options.FirstOrDefault(op => op.ID == optionId);

            if (option != null)
            {
                betCart.RemoveDraft(option);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

       
    }
}
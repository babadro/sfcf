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

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexData
            {
                BetCart = GetCart(),
                ReturnUrl = returnUrl,
                nullBetMessage = "На интерес"
            });
        }

        public RedirectToRouteResult AddToBetCart(int optionId, int? size, string returnUrl)
        {
            Option option = repository.Options.FirstOrDefault(op => op.ID == optionId);

            if (option != null)
            {
                GetCart().AddBetDraft(option, size);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromBetCart(int optionId, string returnUrl)
        {
            Option option = repository.Options.FirstOrDefault(op => op.ID == optionId);

            if (option != null)
            {
                GetCart().RemoveDraft(option);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private BetCart GetCart()
        {
            BetCart cart = (BetCart)Session["Cart"];
            if (cart == null)
            {
                cart = new BetCart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
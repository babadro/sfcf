using System;
using System.Web.Mvc;
using sfcf.Domain.NotDbEntities;

namespace sfcf.WebUI.Binders
{
    public class BetCartModelBinder : IModelBinder
    {
        private const string sessionKey = "BetCart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext){
            
            //get Cart
            BetCart betCart = (BetCart)controllerContext.HttpContext.Session[sessionKey];

            // create the Cart
            if (betCart == null){
                betCart = new BetCart();
                controllerContext.HttpContext.Session[sessionKey] = betCart;
            }
            return betCart;
        }
    }
}
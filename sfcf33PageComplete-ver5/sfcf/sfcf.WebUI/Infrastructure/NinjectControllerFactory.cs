using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using Ninject;
using Moq;
using System.Collections.Generic;
using System.Linq;
using sfcf.Domain.Entities;
using sfcf.Domain.Concrete;
using sfcf.Domain.Abstract;

namespace sfcf.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IRepository>().To<EFRepository>();
        }
    }
}
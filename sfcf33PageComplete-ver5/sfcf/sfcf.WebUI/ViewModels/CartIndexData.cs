using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sfcf.Domain.Entities;
using sfcf.Domain.NotDbEntities;

namespace sfcf.WebUI.ViewModels
{
    public class CartIndexData
    {
        public BetCart BetCart { get; set; }
        public string ReturnUrl { get; set; }
        public string nullBetMessage { get; set; }

    }
}
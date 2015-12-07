using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;
using sfcf.Domain.NotDbEntities;
using sfcf.Domain.Entities;
using sfcf.Domain.Abstract;
using sfcf.WebUI.Controllers;
using sfcf.WebUI.ViewModels;
using Moq;


namespace sfcf.UnitTests
{
    [TestClass]
    public class CartTests
    {
        #region Can_Add_New_BetDrafts
        [TestMethod]
        public void Can_Add_New_BetDrafts()
        {
            // Arrange
            Option op1 = new Option { ID = 1, VotingID = 1, Title = "Option1", Description = "Description option 1" };
            Option op2 = new Option { ID = 2, VotingID = 1, Title = "Option2", Description = "Description option 2" };
            Option op3 = new Option { ID = 3, VotingID = 2, Title = "Option3", Description = "Description option 3" };
            Option op4 = new Option { ID = 4, VotingID = 2, Title = "Option4", Description = "Description option 4" };

            // Arrange
            BetCart target = new BetCart();

            // Act
            target.AddBetDraft(op1, 5);
            target.AddBetDraft(op3, 10);
            target.AddBetDraft(op2, 7);

            BetDraft[] results = target.BetDrafts.OrderBy(b => b.Option.ID).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Size, 7);
            Assert.AreEqual(results[1].Size, 10);
        }
        #endregion

        #region Can_Remove_BetDraft
        [TestMethod]
        public void Can_Remove_BetDraft()
        {
            // Arrange
            Option op1 = new Option { ID = 1, VotingID = 1, Title = "Option1", Description = "Description option 1" };
            Option op2 = new Option { ID = 2, VotingID = 1, Title = "Option2", Description = "Description option 2" };
            Option op3 = new Option { ID = 3, VotingID = 2, Title = "Option3", Description = "Description option 3" };
            Option op4 = new Option { ID = 4, VotingID = 2, Title = "Option4", Description = "Description option 4" };
            Option op5 = new Option { ID = 5, VotingID = 3, Title = "Option5", Description = "Description option 5" };
            Option op6 = new Option { ID = 6, VotingID = 3, Title = "Option6", Description = "Description option 6" };
            Option op7 = new Option { ID = 7, VotingID = 4, Title = "Option7", Description = "Description option 7" };
            Option op8 = new Option { ID = 8, VotingID = 4, Title = "Option8", Description = "Description option 8" };
            Option op9 = new Option { ID = 9, VotingID = 4, Title = "Option9", Description = "Description option 9" };

            // Arrange
            BetCart target = new BetCart();
            
            // Arrange
            target.AddBetDraft(op1, 10);
            target.AddBetDraft(op3, 7);
            target.AddBetDraft(op5, 15);
            target.AddBetDraft(op9, 12);
            target.AddBetDraft(op2, 5);

            // Act
            target.RemoveDraft(op9);

            // Assert
            Assert.AreEqual(0, target.BetDrafts.Where(b => b.Option == op9).Count());
            Assert.AreEqual(3, target.BetDrafts.Count());

        }
        #endregion

        #region Calculate_Total_Size
        [TestMethod]
        public void Calculate_BetCart_Total()
        {
            // Arrange
            Option op1 = new Option { ID = 1, VotingID = 1, Title = "Option1", Description = "Description option 1" };
            Option op2 = new Option { ID = 2, VotingID = 1, Title = "Option2", Description = "Description option 2" };
            Option op3 = new Option { ID = 3, VotingID = 2, Title = "Option3", Description = "Description option 3" };
            Option op4 = new Option { ID = 4, VotingID = 2, Title = "Option4", Description = "Description option 4" };
            Option op5 = new Option { ID = 5, VotingID = 3, Title = "Option5", Description = "Description option 5" };
            Option op6 = new Option { ID = 6, VotingID = 3, Title = "Option6", Description = "Description option 6" };

            // Arrange
            BetCart target = new BetCart();

            // Act
            target.AddBetDraft(op1, 10);
            target.AddBetDraft(op3, 20);
            target.AddBetDraft(op2, 5);
            target.AddBetDraft(op6, 25);

            int? result = target.TotalSize();

            // Assert
            Assert.AreEqual(50, result);

        }
        #endregion

        #region Can_Clear_BetCart
        [TestMethod]
        public void Can_Clear_BetCart()
        {
            // Arrange
            Option op1 = new Option { ID = 1, VotingID = 1, Title = "Option1", Description = "Description option 1" };
            Option op2 = new Option { ID = 2, VotingID = 1, Title = "Option2", Description = "Description option 2" };
            Option op3 = new Option { ID = 3, VotingID = 2, Title = "Option3", Description = "Description option 3" };
            Option op4 = new Option { ID = 4, VotingID = 2, Title = "Option4", Description = "Description option 4" };

            // Arrange
            BetCart target = new BetCart();

            // Arrange
            target.AddBetDraft(op1, 10);
            target.AddBetDraft(op4, 20);

            // Act
            target.Clear();

            // Assert
            Assert.AreEqual(0, target.BetDrafts.Count());
        }
        #endregion

        #region Can_Add_To_BetCart
        [TestMethod]
        public void Can_Add_To_BetCart()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Options).Returns(new Option[]{
                new Option {ID = 1, Title = "Option1", Description = "Description1"},
            }.AsQueryable());

            BetCart betCart = new BetCart();

            // Arrange
            BetCartController target = new BetCartController(mock.Object);

            // Act
            target.AddToBetCart(betCart, 1, 25, null);

            // Assert
            Assert.AreEqual(betCart.BetDrafts.Count(), 1);
            Assert.AreEqual(betCart.BetDrafts.ToArray()[0].Option.ID, 1);
        }
        #endregion

        #region Adding_Bet_To_BetCart_Goes_To_Cart_Screen()
        [TestMethod]
        public void Adding_Bet_To_BetCart_Goes_To_Cart_Screen()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Options).Returns(new Option[]{
                new Option {ID = 1, Title = "Option1", Description = "Description1"},
            }.AsQueryable());

            BetCart betCart = new BetCart();

            // Arrange
            BetCartController target = new BetCartController(mock.Object);

            // Act
            RedirectToRouteResult result = target.AddToBetCart(betCart, 2, 20, "testUrl");

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "testUrl");

            
        }
        #endregion

        #region Can_View_BetCart_Contents
        [TestMethod]
        public void Can_View_BetCart_Contents()
        {
            // Arrange
            BetCart betCart = new BetCart();

            // Arrange
            BetCartController target = new BetCartController(null);

            // Act
            CartIndexData result = (CartIndexData)target.Index(betCart, "testUrl").ViewData.Model;

            // Assert
            Assert.AreSame(betCart, result.BetCart);
            Assert.AreEqual("testUrl", result.ReturnUrl);
        }
        #endregion
    }
}

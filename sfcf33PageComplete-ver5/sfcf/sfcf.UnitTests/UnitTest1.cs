using System;
using Moq;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using sfcf.Domain.Abstract;
using sfcf.Domain.Entities;

using sfcf.WebUI.ViewModels;
using sfcf.WebUI.Controllers;



namespace sfcf.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        
        #region Can_Filter_Voting
        [TestMethod]
        public void Can_Filter_Voting()
        {
            // Arrang
            // - create the mock repository

            Mock<IRepository> mock = new Mock<IRepository>();
            
            mock.Setup(m => m.Votings).Returns(new Voting[]{
                 new Voting
                {
                    ID = 1,
                    Title="Название голосования 1",
                    CategoryID=1,
                    Description="Описание голосования 1",
                    DeadLine=DateTime.Parse("2018-12-31")                        
                },
                
                new Voting
                {
                    ID = 2,
                    Title="Название голосования 2",
                    CategoryID=5,
                    Description="Описание голосования 2",
                    DeadLine=DateTime.Parse("2015-12-31")                        
                },
                new Voting
                {
                    ID = 3,
                    Title="Название голосования 3",
                    CategoryID=1,
                    Description="Описание голосования 3",
                    DeadLine=DateTime.Parse("2016-12-31")                        
                },
                new Voting
                {
                    ID = 4,
                    Title="Название голосования 4",
                    CategoryID=2,
                    Description="Описание голосования 4",
                    DeadLine=DateTime.Parse("2016-12-31")                        
                }
            }.AsQueryable());

            // Arrange
            VotingController controller = new VotingController(mock.Object);
            controller.pageSize = 50;

            // Action
            Voting[] result = ((VotingListData)controller.List(1, null).Model)
                .Votings.ToArray();

            // Assert
            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(result[0].Title == "Название голосования 1" && result[0].CategoryID == 1);
            Assert.IsTrue(result[1].Title == "Название голосования 3" && result[1].CategoryID == 1);
        }        
        #endregion

        #region Can_Create_Categories
        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            // - create the mock repository
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Categories).Returns(new Category[] {
                new Category {ID = 1, Name = "C1", Description = "DC1"},
                new Category {ID = 2, Name = "C2", Description = "DC2"},
                new Category {ID = 3, Name = "C3", Description = "DC3"},
                new Category {ID = 4, Name = "C4", Description = "DC4"}
            }.AsQueryable());

            // Arrange
            CategoryNavController target = new CategoryNavController(mock.Object);

            // Act
            Category[] results = ((IEnumerable<Category>)target.Menu().Model).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 4);
            Assert.AreEqual(results[0].Name, "C1");
            Assert.AreEqual(results[1].Name, "C2");
            Assert.AreEqual(results[2].Name, "C3");
            Assert.AreEqual(results[3].Name, "C4");
        }

        #endregion

    }
}

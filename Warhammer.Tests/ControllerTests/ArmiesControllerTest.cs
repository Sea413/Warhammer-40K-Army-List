using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using WarHammer.Models;
using Moq;
using WarHammer.Controllers;
using WarHammer.Models.Repositories;
using Xunit;

namespace Warhammer.Tests.ControllerTests
{
    public class ArmiesControllerTest
    {
        EFArmyRepository db = new EFArmyRepository(new TestDbContext());
        Mock<IArmyRepository> mock = new Mock<IArmyRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Armies).Returns(new Army[]
            {
                new Army
                {
                    ArmyId = 1,
                    Name = "Space Hounds",
                    Description = "Space Hounds are known for their crazy battle frenzy!"
                },
                new Army
                {
                    ArmyId = 2,
                    Name = "Goblin Raiders",
                    Description = "Goblin raiders are big fans of raiding, raiding is their thing."
                },
                new Army {ArmyId = 3, Name = "Eldar Darkguard", Description = "The are really cool and stuff"}
            }.AsQueryable());
        }

        [Fact]
        public void Mock_IndexArmyList_Test()
        {
            //Arrange 
            DbSetup();
            ArmiesController controller = new ArmiesController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType <ViewResult>(result);
        }

        [Fact]
        public void Mock_ConfirmEntry_Test()
        {
            //Arrange 
            DbSetup();
            ArmiesController controller = new ArmiesController(mock.Object);
            Army testArmy = new Army();
            testArmy.ArmyId = 1;
            testArmy.Name = "Space Hounds";
            testArmy.Description = "Space Hounds are known for their crazy battle frenzy!";

            //Act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Army>;

            //Assert 
            Assert.Contains<Army>(testArmy, collection);
        }

        [Fact]
        public void DB_CreateNewEntry_Test()
        {
            //Arrange
            ArmiesController controller = new ArmiesController(db);
            Army testArmy = new Army();
            testArmy.Name = "New Army";
            testArmy.Description = "TestDb Army";

            //Act 
            controller.Create(testArmy);
            var collection = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Army>;
            //Assert
            Assert.Contains<Army>(testArmy, collection);
        }
    }
}

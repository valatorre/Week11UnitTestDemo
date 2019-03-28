using System;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDemo.Tests
{
    [TestClass]
    public class PersonOrchestratorTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestMethod]
        public void GetAllPeopleShouldReturn2()
        {
            // Arrange 
            var personOrchestrator = _mocker.Create<PersonOrchestrator>();

            // Act
            var people = personOrchestrator.GetAllPeople();

            // Assert
            Assert.AreEqual(2, people.Count);
        }

        [TestMethod]
        public void TodayIsYourBirthdayIsTrueOnBirthday()
        {
            // Arrange
            _mocker.GetMock<IDateTimeService>()
                .Setup(x => x.Now())
                .Returns(new DateTime(2020, 3, 28));

            var person = new PersonViewModel
            {
                FirstName = "Steve",
                LastName = "Jobs",
                Birthdate = new DateTime(1955, 3, 28)
            };

            var personOrchestrator = _mocker.Create<PersonOrchestrator>();

            // Act
            var isBirthday = personOrchestrator.IsTodayYourBirthday(person);

            // Assert
            Assert.IsTrue(isBirthday);
        }
    }
}

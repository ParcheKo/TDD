using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using Domain;
using Domain.Fakes;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Create_Account_With_Valid_Input_Should_Be_In_Active_Status()
        {
            var ownerId = Guid.NewGuid();
            var mock = new Mock<IAccountOwnerValidator>();
            mock.Setup(v => v.IsAccountOwnerValid(ownerId)).Returns(true);

            Account account = new Account(ownerId, 1000, mock.Object);

            mock.Verify(m => m.IsAccountOwnerValid(ownerId), Times.Exactly(1));
            Assert.AreEqual(AccountStatus.Active, account.Status);
        }

        [TestMethod]
        public void Create_Account_With_Valid_Input_Should_Be_In_Active_Status_Stub()
        {
            var ownerId = Guid.NewGuid();
            IAccountOwnerValidator accountOwnerValidator =
                  new Domain.Fakes.StubIAccountOwnerValidator()
                  {
                      IsAccountOwnerValidGuid = (oId) => { return true; }
                  };

            Account account = new Account(ownerId, 1000, accountOwnerValidator);

            Assert.AreEqual(AccountStatus.Active, account.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountWithBalanceException))]
        public void Create_Account_With_Negative_Balance_Should_Get_AccountWithBalanceException()
        {
            var ownerId = Guid.NewGuid();
            var mock = new Mock<IAccountOwnerValidator>();
            mock.Setup(v => v.IsAccountOwnerValid(ownerId)).Returns(true);

            Account account = new Account(ownerId, -1000, mock.Object);
        }

  
    }
}

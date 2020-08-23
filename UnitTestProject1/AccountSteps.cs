using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class AccountSteps
    {
        [Given(@"I want Create an account with balance (.*)")]
        public void GivenIWantCreateAnAccountWithBalance(int p0)
        {
            ScenarioContext.Current.Add("AccountBalance",p0); 
        }
        
        [When(@"I Create account")]
        public void WhenICreateAccount()
        {
            var ownerId = Guid.NewGuid();
            var balance = ScenarioContext.Current.Get<int>("AccountBalance");
            var accountOwnerValidatorMock = new Mock<IAccountOwnerValidator>();
            accountOwnerValidatorMock.Setup(v => v.IsAccountOwnerValid(ownerId)).Returns(true);

            var account = new Account(ownerId, balance, accountOwnerValidatorMock.Object);
            ScenarioContext.Current.Add("Account", account);

        }

        [Then(@"the account status must be '(.*)' and balance must be (.*)")]
        public void ThenTheAccountStatusMustBeAndBalanceMustBe(string p0, int p1)
        {
          var account=  ScenarioContext.Current.Get<Account>("Account");
            AccountStatus accountStatus = (AccountStatus)Enum.Parse(typeof(AccountStatus), p0, true);
            Assert.AreEqual(p1,account.Balance);
            Assert.AreEqual(accountStatus, account.Status);
        }
    }
}

using System;
using LegacyDomain;
using LegacyDomain.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ministry.ReflectionHelper;
using FluentAssertions;
namespace LegacyTestProject
{
    [TestClass]
    public class LegacyAccountTest
    {
        [TestMethod]
       // [ExpectedException(typeof(LegacyOwnerIsNotValidException))]
        public void Create_LegacyAccount_With_InValid_Owner_Must_Get_LegacyOwnerIsNotValidException()
        {

            using (ShimsContext.Create())
            {
                ShimLegacyAccountOwnerValidator.AllInstances.IsAccountOwnerValidGuid = (a, c) => { return false; };

              //  LegacyAccount account =
                Action accountCreaion = () => new LegacyAccount(Guid.NewGuid(), 1000);

                accountCreaion.Should().Throw<LegacyOwnerIsNotValidException>();
            }
        }

        [TestMethod]
       
        public void Create_LegacyAccount_With_Valid_Owner()
        {
            using (ShimsContext.Create())
            {
                ShimLegacyAccountOwnerValidator.AllInstances.IsAccountOwnerValidGuid = (a, c) => { return true; };
                var ownerId = Guid.NewGuid();
                LegacyAccount account = new LegacyAccount(ownerId, 1000);

                account.OwnerId.Should().Be(ownerId);
            }
        }
    }
}

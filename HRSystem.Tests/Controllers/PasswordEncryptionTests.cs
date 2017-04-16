using System;

using HRSystem.Helpers;
using NUnit.Framework;

namespace HRSystem.Tests.Controllers
{
    [TestFixture]
    public class PasswordEncryptionTests
    {
        [Test]
        public void Check_Hashed_Password_Length()
        {
            var hashedLength = 40;
            var password = "Password";

            var result = EncryptPassword.Encode(password);

            Assert.AreEqual(hashedLength, result.Length);
        }

    }
}

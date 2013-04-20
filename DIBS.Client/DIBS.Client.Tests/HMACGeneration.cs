using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DIBS.Client.Tests
{
    [TestClass]
    public class HMACGeneration
    {
        private const string KEY =
            "f2355e3bb049eaa89e4e07a055042e9793b947cd49d09537fbb72e6e1f9a80e2f2355e3bb049eaa89e4e07a055042e9793b947cd49d09537fbb72e6e1f9a80e2";

        [TestMethod]
        public void Generate_HMAC_For_Empty_DibsPost()
        {
            // Arrange
            var post = new DibsPost();

            // Act
            string mac = post.GenerateHMAC(KEY);

            // Assert
            string expected = HMACGenerator.HashHMACHex(KEY,
                                                        "acceptreturnurl=&amount=&callbackurl=&cancelreturnurl=&currency=&language=&merchant=&orderid=");
            Assert.AreEqual(expected, mac);
        }

        [TestMethod]
        public void Genereate_HMAC_For_Test_DibsPost()
        {
            // Arrange
            var post = new DibsPost();
            post.Test = "1";
            // Act
            string mac = post.GenerateHMAC(KEY);

            // Assert
            string expected = HMACGenerator.HashHMACHex(KEY,
                                                        "acceptreturnurl=&amount=&callbackurl=&cancelreturnurl=&currency=&language=&merchant=&orderid=&test=1");
            Assert.AreEqual(expected, mac);
        }
    }
}
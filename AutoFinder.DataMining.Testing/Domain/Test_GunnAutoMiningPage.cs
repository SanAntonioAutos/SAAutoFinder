using AutoFinder.DataMining.Domain;
using AutoFinder.DataMining.Domain.Interfaces;
using NUnit.Framework;

namespace AutoFinder.DataMining.Testing.Domain {
    [TestFixture()]
    public class Test_GunnAutoMiningPage {
#region Private Members
        private MinableDealer _dealer;
        private string _testHtml;
#endregion

#region Private Members
        [TestFixtureSetUp()]
        public void TestFixtureSetup() {
            this._dealer = new MinableDealer(
                "CBD649D8-007C-428A-8BA1-793F931490AE",
                "Gunn Auto",
                "http://gunnauto.com/inventory/view/records10000/",
                "GunnAutoMiningPage"
            );
            this._testHtml = System.IO.File.ReadAllText("Domain/Html/GunnAuto_20131226.html");
        }

        [TestFixtureTearDown()]
        public void TestFixtureTeardown() {
            this._dealer = null;
            this._testHtml = null;
        }
#endregion

#region Tests
        [Test()]
        public void TestMine() {
            IMiningPage gunnAutoMiningPage = new GunnAutoMiningPage(this._dealer);
            gunnAutoMiningPage.Mine(this._testHtml);
        }
#endregion
    }
}
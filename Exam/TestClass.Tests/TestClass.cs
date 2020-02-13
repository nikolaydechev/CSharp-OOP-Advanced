using NUnit.Framework;

namespace TestClass.Tests
{
    [TestFixture]
    public class TestClass
    {
        private MissionController missionController;

        [SetUp]
        public void TestInitialize()
        {
            this.missionController = new MissionController(new Army(), new WareHouse());
        }
        
        [Test]
        public void MissionCountTest()
        {
            this.missionController.Missions.Enqueue(new Easy(14.7));
            this.missionController.Missions.Enqueue(new Medium(40));
            this.missionController.Missions.Enqueue(new Hard(50));

            Assert.AreEqual(3, this.missionController.Missions.Count);
        }


    }
}

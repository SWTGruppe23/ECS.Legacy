using NUnit.Framework;
using ECS.NSubstitute;
using NSubstitute;

namespace ECS.NSubstitute.Test.Unit
{
    // Naar vi har valgt at placere FakeTempSensor i test projektet, er vi nødt til at bruge constructor injection, da vi ikke kan 
    // give ECS.Refactored en dependency til ECS.Refactored.Test.Unit, da vi da vil risikere circular dependencies. Derfor kan vi ikke naa
    // FakeTempSensor fra ECS.Refactored
    public class FakeTempSensor : ITempSensor
    {
        public int temperature { get; set; }

        public int GetTemp()
        {
            return temperature;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }

    public class Tests
    {
        private ECS _uut;
        private IHeater _fakeHeater = Substitute.For<IHeater>();
        private ITempSensor _fakesSensor = Substitute.For<ITempSensor>();
        [SetUp]
        public void Setup()
        {
            int threshold = 32;
            _uut = new ECS(threshold, _fakesSensor, _fakeHeater);
        }

        [Test]
        public void TempSensor_GetTemp_is5()
        {
            _fakesSensor.GetTemp().Returns(5);
            Assert.That(_uut.GetCurTemp(), Is.EqualTo(5));//test
        }

        [Test]
        public void TempSensor_GetTemp_isCalled()
        {
            _fakesSensor.ClearReceivedCalls();
            _uut.GetCurTemp();
            _fakesSensor.Received(1).GetTemp();
        }
    }
}
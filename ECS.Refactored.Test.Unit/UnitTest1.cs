using System;
using NUnit.Framework;
using ECS.Refactored;

namespace ECS.Refactored.Test.Unit
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
        private FakeTempSensor _fake = new FakeTempSensor();
        [SetUp]
        public void Setup()
        {
            int threshold = 32;
            _uut = new ECS(threshold, _fake);
        }

        [Test]
        public void TempSensor_GetTemp_is5()
        {
            _fake.temperature = 5;
            Assert.That(_uut.GetCurTemp(), Is.EqualTo(5));
        }
    }
}
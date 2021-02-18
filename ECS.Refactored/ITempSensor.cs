using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Refactored
{
    public interface ITempSensor
    {
        public int GetTemp();

        public bool RunSelfTest();
    }
}

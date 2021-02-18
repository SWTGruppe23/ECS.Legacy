using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Refactored
{
    interface ITempSensor
    {
        public int GetTemp();

        public bool RunSelfTest();
    }
}

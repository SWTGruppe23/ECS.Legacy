namespace ECS.NSubstitute
{
    public interface ITempSensor
    {
        public int GetTemp();

        public bool RunSelfTest();
    }
}

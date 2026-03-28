public class ACVoltageMode : IMultimeterMode
{
    public MeasurementMode Mode => MeasurementMode.ACVoltage;

    public float Calculate(float power, float resistance)
    {
        return 0.01f;
    }
}
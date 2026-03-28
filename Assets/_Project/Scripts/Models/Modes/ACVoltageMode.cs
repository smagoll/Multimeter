public class ACVoltageMode : IMultimeterMode
{
    public MeasurementMode Mode => MeasurementMode.ACVoltage;
    public string Label => "V~";

    public float Calculate(float power, float resistance)
    {
        return 0.01f;
    }
}
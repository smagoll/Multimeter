public class NeutralMode : IMultimeterMode
{
    public MeasurementMode Mode => MeasurementMode.Neutral;
    public string Label => null;

    public float Calculate(float power, float resistance)
    {
        return 0f;
    }
}
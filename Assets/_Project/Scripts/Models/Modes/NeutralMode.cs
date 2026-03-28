public class NeutralMode : IMultimeterMode
{
    public MeasurementMode Mode => MeasurementMode.Neutral;

    public float Calculate(float power, float resistance)
    {
        return 0f;
    }
}
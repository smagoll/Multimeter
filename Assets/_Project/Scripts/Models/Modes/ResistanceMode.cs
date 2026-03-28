public class ResistanceMode : IMultimeterMode
{
    public MeasurementMode Mode => MeasurementMode.Resistance;

    public float Calculate(float power, float resistance)
    {
        return resistance;
    }
}
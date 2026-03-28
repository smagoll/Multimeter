public class ResistanceMode : IMultimeterMode
{
    public MeasurementMode Mode => MeasurementMode.Resistance;
    public string Label => "Ω";

    public float Calculate(float power, float resistance)
    {
        return resistance;
    }
}
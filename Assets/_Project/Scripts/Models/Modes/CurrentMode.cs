using UnityEngine;

public class CurrentMode : IMultimeterMode
{
    public MeasurementMode Mode => MeasurementMode.Current;

    public float Calculate(float power, float resistance)
    {
        return Mathf.Sqrt(power / resistance);
    }
}
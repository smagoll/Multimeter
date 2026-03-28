using UnityEngine;

public class DCVoltageMode : IMultimeterMode
{
    public MeasurementMode Mode => MeasurementMode.DCVoltage;

    public float Calculate(float power, float resistance)
    {
        return Mathf.Sqrt(power * resistance);
    }
}
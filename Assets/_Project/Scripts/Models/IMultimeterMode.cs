public interface IMultimeterMode
{
    MeasurementMode Mode { get; }
    float Calculate(float power, float resistance);
}
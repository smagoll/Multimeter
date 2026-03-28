using JetBrains.Annotations;

public interface IMultimeterMode
{
    MeasurementMode Mode { get; }
    [CanBeNull] string Label { get; } 
    float Calculate(float power, float resistance);
}
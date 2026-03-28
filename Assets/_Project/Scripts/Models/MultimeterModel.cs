using System;
using System.Collections.Generic;

public class MultimeterModel
{
    private readonly List<IMultimeterMode> _modes;
    private int _currentIndex;

    private float _power;
    private float _resistance;

    public IMultimeterMode CurrentMode => _modes[_currentIndex];
    public IReadOnlyList<IMultimeterMode> Modes => _modes;

    public event Action<IMultimeterMode, float> OnChanged;

    public MultimeterModel(List<IMultimeterMode> modes)
    {
        _modes = modes;
    }

    public void SetPower(float power)
    {
        _power = power;
    }

    public void SetResistance(float resistance)
    {
        _resistance = resistance;
    }

    public void NextMode()
    {
        _currentIndex = (_currentIndex + 1) % _modes.Count;
        Notify();
    }

    public void PreviousMode()
    {
        _currentIndex = (_currentIndex - 1 + _modes.Count) % _modes.Count;
        Notify();
    }

    private void Notify()
    {
        float value = CurrentMode.Calculate(_power, _resistance);
        OnChanged?.Invoke(CurrentMode, value);
    }
}
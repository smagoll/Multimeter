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

    public MultimeterModel(List<IMultimeterMode> modes, float power, float resistance)
    {
        _modes = modes;
        _power = power;
        _resistance = resistance;
    }

    public void Next()
    {
        _currentIndex = (_currentIndex + 1) % _modes.Count;
        Update();
    }

    public void Previous()
    {
        _currentIndex = (_currentIndex - 1 + _modes.Count) % _modes.Count;
        Update();
    }

    private void Update()
    {
        float value = CurrentMode.Calculate(_power, _resistance);
        OnChanged?.Invoke(CurrentMode, value);
    }
}
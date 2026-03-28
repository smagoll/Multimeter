using System;
using System.Collections.Generic;
using UnityEngine;

public class MultimeterController : MonoBehaviour
{
    public event Action OnActivated;
    public event Action OnDeactivated;
    public event Action<IMultimeterMode, float> OnChanged;
    
    [SerializeField] private MultimeterView view;
    [SerializeField] private MultimeterHighlightView _highlightView;

    private MultimeterModel _model;
    
    public IReadOnlyList<IMultimeterMode> Modes => _model.Modes;
    
    private bool isActive;

    private void Awake()
    {
        var modes = new List<IMultimeterMode>()
        {
            new NeutralMode(),
            new DCVoltageMode(),
            new ACVoltageMode(),
            new CurrentMode(),
            new ResistanceMode(),
        };

        _model = new MultimeterModel(modes);
        _model.SetPower(400);
        _model.SetResistance(1000);

        _model.OnChanged += HandleChanged;
    }
    
    public void Next() => _model.NextMode();
    public void Previous() => _model.PreviousMode();
    
    public void Activate()
    {
        isActive = true;
        _highlightView.SetHighlight(true);
        
        OnActivated?.Invoke();
    }

    public void Deactivate()
    {
        isActive = false;
        _highlightView.SetHighlight(false);
        
        OnDeactivated?.Invoke();
    }
    
    private void HandleChanged(IMultimeterMode mode, float value)
    {
        view.UpdateView(mode, value);
        OnChanged?.Invoke(mode, value);
    }

    private void OnDestroy()
    {
        _model.OnChanged -= HandleChanged;
    }
}
using System;
using System.Text;
using TMPro;
using UnityEngine;

public class UIMultimeter : MonoBehaviour
{
    [SerializeField] private MultimeterController multimeterController;
    [SerializeField] private TextMeshProUGUI valuesText;

    private readonly StringBuilder sb = new StringBuilder();

    private void Start()
    {
        Hide();
        UpdateText(MeasurementMode.Neutral, 0);
    }

    private void Show()
    {
        valuesText.gameObject.SetActive(true);
    }

    private void Hide()
    {
        valuesText.gameObject.SetActive(false);
    }

    private void OnChanged(IMultimeterMode currentMode, float value)
    {
        UpdateText(currentMode.Mode, value);
    }

    private void UpdateText(MeasurementMode modeType, float value)
    {
        sb.Clear();

        foreach (var mode in multimeterController.Modes)
        {
            float v = mode.Mode == modeType ? value : 0f;
            if(mode.Label != null) AppendLine(mode.Label, v);
        }

        valuesText.text = sb.ToString();
    }
    
    private void AppendLine(string label, float value)
    {
        sb.Append(label);
        sb.Append("  ");
        sb.AppendLine(value.ToString("F2"));
    }

    private void OnEnable()
    {
        multimeterController.OnActivated += Show;
        multimeterController.OnDeactivated += Hide;
        multimeterController.OnChanged += OnChanged;
    }

    private void OnDisable()
    {
        multimeterController.OnActivated -= Show;
        multimeterController.OnDeactivated -= Hide;
        multimeterController.OnChanged -= OnChanged;
    }
}
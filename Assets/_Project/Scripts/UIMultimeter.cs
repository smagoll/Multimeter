using System;
using System.Text;
using TMPro;
using UnityEngine;

public class UIMultimeter : MonoBehaviour
{
    [SerializeField] private MultimeterController multimeterController;
    [SerializeField] private TextMeshProUGUI valuesText;

    private readonly StringBuilder sb = new StringBuilder();

    private void Awake()
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
    
    private void MultimeterControllerOnChanged(IMultimeterMode mode, float value)
    {
        UpdateText(mode.Mode, value);
    }

    private void UpdateText(MeasurementMode mode, float value)
    {
        sb.Clear();

        AppendLine("V", mode == MeasurementMode.DCVoltage ? value : 0f);
        AppendLine("A", mode == MeasurementMode.Current ? value : 0f);
        AppendLine("Ω", mode == MeasurementMode.Resistance ? value : 0f);
        AppendLine("V~", mode == MeasurementMode.ACVoltage ? value : 0f);

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
        multimeterController.OnChanged += MultimeterControllerOnChanged;
    }

    private void OnDisable()
    {
        multimeterController.OnActivated -= Show;
        multimeterController.OnDeactivated -= Hide;
    }
}
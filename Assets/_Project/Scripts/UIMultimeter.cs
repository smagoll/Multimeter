using System;
using System.Linq;
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
        UpdateUI(MeasurementMode.Neutral, 0);
    }

    private void Show() => valuesText.gameObject.SetActive(true);

    private void Hide() => valuesText.gameObject.SetActive(false);

    private void OnChanged(IMultimeterMode currentMode, float value)
    {
        UpdateUI(currentMode.Mode, value);
    }

    private void UpdateUI(MeasurementMode mode, float value)
    {
        var lines = multimeterController.Modes.Select(m =>
        {
            float v = m.Mode == mode ? value : 0f;
            return m.Label != null ? $"{m.Label}  {v:F2}" : null;
        });

        valuesText.text = string.Join("\n", lines);
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
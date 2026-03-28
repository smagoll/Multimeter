using System.Linq;
using TMPro;
using UnityEngine;

public class MultimeterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro display;
    [SerializeField] private Transform knob;
    [SerializeField] private MultimeterModeView[] modeViews;

    public void UpdateView(IMultimeterMode mode, float value)
    {
        display.text = value.ToString("F2");
        RotateKnob(mode);
    }

    private void RotateKnob(IMultimeterMode mode)
    {
        var target = modeViews.FirstOrDefault(x => x.Mode == mode.Mode);
        if (target == null) return;

        Vector3 direction = target.transform.position - knob.position;

        knob.up = direction.normalized;
    }
}
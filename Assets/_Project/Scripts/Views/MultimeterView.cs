using TMPro;
using UnityEngine;

public class MultimeterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro display;
    [SerializeField] private Transform knob;
    [SerializeField] private MultimeterModeView[] modesView;

    public void UpdateView(IMultimeterMode mode, float value)
    {
        Debug.Log(mode.Mode.ToString());
        
        display.text = $"{value:F2}";

        RotateKnob(mode);
    }

    private void RotateKnob(IMultimeterMode mode)
    {
        foreach (var m in modesView)
        {
            if (m.Mode != mode.Mode)
                continue;

            knob.up = m.transform.position - knob.position;
            knob.Rotate(0f, 180f, 0);
            return;
        }
    }
}
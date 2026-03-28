using TMPro;
using UnityEngine;

public class MultimeterModeView : MonoBehaviour
{
    [SerializeField] private MeasurementMode mode;
    
    public MeasurementMode Mode { get => mode; set => mode = value; }
}
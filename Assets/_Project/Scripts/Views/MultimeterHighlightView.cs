using System;
using TMPro;
using UnityEngine;

public class MultimeterHighlightView : MonoBehaviour
{
    [SerializeField] private TextMeshPro display;

    private void Awake()
    {
        Disable();
    }

    public void SetHighlight(bool highlight)
    {
        if (highlight)
            Enable();
        else
            Disable();
    }
    
    private void Enable()
    {
        display.gameObject.SetActive(true);
    }

    private void Disable()
    {
        display.gameObject.SetActive(false);
    }
}
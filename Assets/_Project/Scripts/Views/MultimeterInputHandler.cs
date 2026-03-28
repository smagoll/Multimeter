using UnityEngine;

public class MultimeterInputHandler : MonoBehaviour
{
    [SerializeField] private MultimeterController _controller;

    private bool _isHovered;

    private void OnMouseEnter()
    {
        _isHovered = true;
        _controller.Activate();
    }

    private void OnMouseExit()
    {
        _isHovered = false;
        _controller.Deactivate();
    }

    private void Update()
    {
        if (!_isHovered) return;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll < 0f) _controller.Next();
        else if (scroll > 0f) _controller.Previous();
    }
}
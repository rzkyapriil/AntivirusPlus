using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private bool mouseEnter = false;
    private bool mouseDown = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEnter = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseDown = true;
    }

    void Update()
    {
        if (mouseEnter)
        {
            FindObjectOfType<AudioManager>().PlayAudio("MouseEnter");
            mouseEnter = false;
        }

        if (mouseDown)
        {
            FindObjectOfType<AudioManager>().PlayAudio("Click");
            mouseDown = false;
        }
    }
}

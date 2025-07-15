using UnityEngine;
using cakeslice;
public class InteractiveObject : MonoBehaviour
{
    private Outline outline;

    void Start()
    {
        outline = GetComponent<Outline>();
        if (outline != null)
            outline.enabled = false;
    }

    void OnMouseEnter()
    {
        if (outline != null)
            outline.enabled = true;
    }

    void OnMouseExit()
    {
        if (outline != null)
            outline.enabled = false;
    }
}
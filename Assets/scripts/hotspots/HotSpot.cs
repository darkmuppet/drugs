using UnityEngine;
using System.Collections;

public abstract class HotSpot : MonoBehaviour
{

    void OnMouseOver()
    {
        HighlightHotSpot();
    }

    void OnMouseUpAsButton()
    {
        OnHotSpotClicked();
    }

    void Update()
    {
        // TODO change highlight button
        if (Input.GetMouseButtonDown(1))
        {
            HighlightHotSpot();
        }
    }

    void HighlightHotSpot()
    {
        // TODO glow or something
    }

    protected abstract void OnHotSpotClicked();

}

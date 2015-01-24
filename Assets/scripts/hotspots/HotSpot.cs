using UnityEngine;
using System.Collections;

public abstract class HotSpot : MonoBehaviour
{

    public Transform playerTarget;

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

    void OnHotSpotClicked()
    {
        GameController.Instance.Player.MoveToHotSpot(this);
    }

    public abstract void HotSpotReached();

}

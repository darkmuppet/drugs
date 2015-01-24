using UnityEngine;
using System.Collections;

public class HotSpotCat : HotSpot
{
    public GameObject vomitHotSpot;
    public override void OnPerformAction()
    {
        // TODO cat vomits activate vomit-hotspot
        vomitHotSpot.SetActive(true);

    }
}

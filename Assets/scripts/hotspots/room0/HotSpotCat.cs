using UnityEngine;
using System.Collections;

public class HotSpotCat : HotSpot
{

    public GameObject vomitHotSpot;

    public override IEnumerator OnPerformAction()
    {
        // TODO cat vomits activate vomit-hotspot
        vomitHotSpot.SetActive(true);

        yield return null;
    }
}

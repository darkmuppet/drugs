using UnityEngine;
using System.Collections;

public class HotSpotCat : HotSpot
{

    public GameObject vomitHotSpot;
    public GameObject vomitGameObject;

    public override IEnumerator OnPerformAction()
    {
        
        // TODO cat vomits animation
        vomitHotSpot.SetActive(true);
        vomitGameObject.SetActive(true);

        yield return null;
    }
}

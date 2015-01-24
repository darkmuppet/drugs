using UnityEngine;
using System.Collections;

public class HotSpotCage : HotSpot
{

    public GameObject catHotSpot;

    public override IEnumerator OnPerformAction()
    {
        catHotSpot.SetActive(true);
        yield return null;
        // TODO play bird/cage animation, move cat
    }
}

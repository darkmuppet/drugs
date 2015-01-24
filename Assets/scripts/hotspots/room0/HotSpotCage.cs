using UnityEngine;
using System.Collections;

public class HotSpotCage : HotSpot
{

    public GameObject catHotSpot;

    public override void OnPerformAction()
    {
        // TODO play bird/cage animation, move cat
        catHotSpot.SetActive(true);
    }
}

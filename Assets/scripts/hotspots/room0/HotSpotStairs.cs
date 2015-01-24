using UnityEngine;
using System.Collections;

public class HotSpotStairs : HotSpot {
    public override IEnumerator OnPerformAction()
    {
        Debug.Log(("FINISHED LEVEL!"));
      yield return null;

    }
}

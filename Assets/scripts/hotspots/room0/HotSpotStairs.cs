using UnityEngine;
using System.Collections;

public class HotSpotStairs : HotSpot {
    public override IEnumerator OnPerformAction()
    {
        Debug.Log(("FINISHED LEVEL!"));
        GameController.Instance.SwitchToRoom("room_2");
      yield return null;

    }
}

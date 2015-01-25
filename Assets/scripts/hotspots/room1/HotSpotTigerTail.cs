using UnityEngine;
using System.Collections;

public class HotSpotTigerTail : HotSpot
{

    private int state;

    public void SetState(int newState)
    {
        state = newState;
    }

    public override IEnumerator OnPerformAction()
    {
        // TODO fire exclamation mark fire check if candle is there


        yield return null;
    }
}

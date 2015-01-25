using UnityEngine;
using System.Collections;

public class HotSpotHole : HotSpot
{
    public GameObject doorGameObject;
    public override IEnumerator OnPerformAction()
    {

        // TODO activate door
        doorGameObject.SetActive(true);
        yield return null;
    }
}

using UnityEngine;
using System.Collections;

public class HotSpotCage : HotSpot
{
    public GameObject birdShockedGameObject;
    public GameObject birdGameObject;
    public Sprite birdSprite;
    public GameObject catHotSpot;

    public override IEnumerator OnPerformAction()
    {
        // TODO play bird/cage animation, move cat

        birdShockedGameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        birdShockedGameObject.SetActive(false);

        birdGameObject.GetComponent<SpriteRenderer>().sprite = birdSprite;

        catHotSpot.SetActive(true);
        yield return null;
    }
}

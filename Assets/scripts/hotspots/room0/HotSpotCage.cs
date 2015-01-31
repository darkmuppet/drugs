using UnityEngine;
using System.Collections;

public class HotSpotCage : HotSpot
{
    public GameObject birdShockedGameObject;
    public GameObject birdGameObject;

    public Sprite birdSprite;

    public GameObject catFrontGameObject;
    public GameObject catSideGameObject;

    public GameObject catHotSpot;

    public override IEnumerator OnPerformAction()
    {
        // TODO play bird/cage animation, move cat

        GameController.Instance.Player.TriggerAnimation("shakecage");

        yield return new WaitForSeconds(1);

        GameController.Instance.Player.TriggerAnimation("idle");

        birdShockedGameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        birdShockedGameObject.SetActive(false);

        catFrontGameObject.SetActive(false);
        catSideGameObject.SetActive(true);

        Vector3 newCatPos = new Vector3(-1.234f, catSideGameObject.transform.position.y, catSideGameObject.transform.position.z);



        // TODO trigger walk
        Animator catAnimator = catSideGameObject.GetComponentInChildren<Animator>();
       catAnimator.SetTrigger("walk");
        iTween.MoveTo(catSideGameObject, newCatPos, 2f);
        yield return new WaitForSeconds(2);
        // TODO trigger idle
        catAnimator.SetTrigger("meow");


        birdGameObject.GetComponent<SpriteRenderer>().sprite = birdSprite;

        catHotSpot.SetActive(true);
        yield return null;
    }
}

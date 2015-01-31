using UnityEngine;
using System.Collections;

public class HotSpotCat : HotSpot
{

    public GameObject vomitHotSpot;
    public GameObject vomitGameObject;

    public GameObject catSideGameObject;
    public GameObject catFrontGameObject;

    public override IEnumerator OnPerformAction()
    {
        
        // TODO cat vomits animation

        Vector3 newCatPosFront = new Vector3(-5.65f, -4.73f, catSideGameObject.transform.position.z);
        Vector3 newCatPos = new Vector3(-5.65f, -4.73f, catSideGameObject.transform.position.z);



        // TODO triggr walk
        Animator catAnimator = catSideGameObject.GetComponentInChildren<Animator>();
        catAnimator.SetTrigger("walk");
        iTween.MoveTo(catSideGameObject, newCatPos, 2f);
        yield return new WaitForSeconds(2);
        // TODO trigger idle
        catSideGameObject.SetActive(false);

        catFrontGameObject.transform.position = newCatPosFront;
        Animator catFrontAnimator = catFrontGameObject.GetComponent<Animator>();



        catFrontGameObject.SetActive(true);
        catFrontAnimator.SetTrigger("vomit");
        yield return new WaitForSeconds(0.5f);
        audio.PlayOneShot(clipCustom);
        yield return new WaitForSeconds(1);

        vomitHotSpot.SetActive(true);
        vomitGameObject.SetActive(true);

        catFrontGameObject.SetActive(false);
        catSideGameObject.SetActive(true);
        newCatPos = new Vector3(-7.23f, catSideGameObject.transform.position.y, catSideGameObject.transform.position.z);

        catAnimator.SetTrigger("walk");
        iTween.MoveTo(catSideGameObject, newCatPos, 2f);
        yield return new WaitForSeconds(2);
        catAnimator.SetTrigger("idle");

        yield return null;
    }
}

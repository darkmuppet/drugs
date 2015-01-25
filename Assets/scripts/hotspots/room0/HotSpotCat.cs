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

        Vector3 newCatPosFront = new Vector3(-6.02f, -5.4f, catSideGameObject.transform.position.z);
        Vector3 newCatPos = new Vector3(-6.02f, -5.4f, catSideGameObject.transform.position.z);



        // TODO triggr walk
        Animator catAnimator = catSideGameObject.GetComponentInChildren<Animator>();
        catAnimator.SetTrigger("catwalk");
        iTween.MoveTo(catSideGameObject, newCatPos, 2f);
        yield return new WaitForSeconds(2);
        // TODO trigger idle
        catSideGameObject.SetActive(false);

        catFrontGameObject.transform.position = newCatPosFront;
        Animator catFrontAnimator = catFrontGameObject.GetComponent<Animator>();



        catFrontGameObject.SetActive(true);
        catFrontAnimator.SetTrigger("catvomit");
        yield return new WaitForSeconds(2);


        vomitHotSpot.SetActive(true);
        vomitGameObject.SetActive(true);

        catFrontAnimator.SetTrigger("catidle");

        yield return null;
    }
}

using UnityEngine;
using System.Collections;

public class HotSpotFridge : HotSpot
{


    public GameObject sausageGameObject;
    public GameObject sausageHotSpotGameObject;
    public GameObject yoghurtGameObject;
    public GameObject yoghurtHotSpotGameObject;

    public GameObject spoonGameObject;

    public GameObject fridgeOpenGameObject;

    private bool fridgeClosed = true;



    public override IEnumerator OnPerformAction()
    {
        Debug.Log("sausagegameobject is " + sausageGameObject.activeSelf + " and spoonGameObject is " + spoonGameObject.activeSelf);
        if (fridgeClosed)
        {
            // open fridge
            fridgeOpenGameObject.SetActive(true);
            yoghurtGameObject.SetActive(true);
            yoghurtHotSpotGameObject.SetActive(true);
            sausageGameObject.SetActive(true);
            sausageHotSpotGameObject.SetActive(true);

            fridgeClosed = false;
        }
        else
        {
            if (!sausageGameObject.activeSelf && !yoghurtHotSpotGameObject)
            {
                yoghurtGameObject.SetActive(false);
                fridgeOpenGameObject.SetActive(false);
                deactivateAfterAction = true;
            }
        }
        yield return null;
    }
}

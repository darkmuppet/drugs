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

    public Sprite yoghurtNoSpoon;

    private bool nextItem = false;
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
            if (!sausageGameObject.activeSelf && !spoonGameObject.activeSelf)
            {
                yoghurtGameObject.SetActive(false);
                fridgeOpenGameObject.SetActive(false);
                deactivateAfterAction = true;
            }
        }
        //else
        //{
        //    Debug.Log("nextItem: " + nextItem);
        //    if (!nextItem)
        //    {
        //        Debug.Log("first item");
        //        GameController.Instance.Inventory.Add(spoonGameObject);
        //        SpriteRenderer yoghurtSpriteRenderer = yoghurtGameObject.GetComponent<SpriteRenderer>();
        //        yoghurtSpriteRenderer.sprite = yoghurtNoSpoon;

        //        nextItem = true;
        //    }
        //    else
        //    {
        //        Debug.Log("second item");
        //        GameController.Instance.Inventory.Add(sausageGameObject);
        //        yoghurtGameObject.SetActive(false);
        //        sausageGameObject.SetActive(false);
        //        fridgeOpenGameObject.SetActive(false);
        //        deactivateAfterAction = true;
        //    }
        //}
        yield return null;
    }
}

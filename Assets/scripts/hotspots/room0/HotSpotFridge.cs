using UnityEngine;
using System.Collections;

public class HotSpotFridge : HotSpot
{


    public GameObject sausageGameObject;
    public GameObject spoonGameObject;

    public GameObject fridgeOpenGameObject;
    public GameObject yoghurtGameObject;

    public Sprite yoghurtNoSpoon;

    private bool nextItem = false;
    private bool fridgeClosed = true;



    public override IEnumerator OnPerformAction()
    {
        if (fridgeClosed)
        {
            // open fridge
            fridgeOpenGameObject.SetActive(true);
            yoghurtGameObject.SetActive(true);
            sausageGameObject.SetActive(true);

            fridgeClosed = false;
        }
        else
        {
            Debug.Log("nextItem: " + nextItem);
            if (!nextItem)
            {
                Debug.Log("first item");
                GameController.Instance.Inventory.Add(spoonGameObject);
                SpriteRenderer yoghurtSpriteRenderer = yoghurtGameObject.GetComponent<SpriteRenderer>();
                yoghurtSpriteRenderer.sprite = yoghurtNoSpoon;
               
                nextItem = true;
            }
            else
            {
                Debug.Log("second item");
                GameController.Instance.Inventory.Add(sausageGameObject);
                yoghurtGameObject.SetActive(false);
                sausageGameObject.SetActive(false);
                fridgeOpenGameObject.SetActive(false);
                deactivateAfterAction = true;
            }
        }
        yield return null;
    }
}

using UnityEngine;
using System.Collections;

public class HotSpotFridge : HotSpot
{


    public GameObject item;
    public GameObject item2;

    private bool nextItem = false;



    public override IEnumerator OnPerformAction()
    {
        Debug.Log("nextItem: " + nextItem);
        if (!nextItem)
        {
            Debug.Log("first item");
            GameController.Instance.Inventory.Add(item);
            nextItem = true;
        }
        else
        {
            Debug.Log("second item");
            GameController.Instance.Inventory.Add(item2);
            deactivateAfterAction = true;
        }
        yield return null;
    }
}

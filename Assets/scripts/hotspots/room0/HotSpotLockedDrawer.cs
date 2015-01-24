using UnityEngine;
using System.Collections;

public class HotSpotLockedDrawer : HotSpot
{

    public GameObject item;
    public GameObject item2;

    private bool nextItem = false;



    public override IEnumerator OnPerformAction()
    {
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

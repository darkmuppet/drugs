using UnityEngine;
using System.Collections;

public class HotSpotLockedDrawer : HotSpot
{

    public GameObject item;
    public GameObject item2;


    public override IEnumerator OnPerformAction()
    {
        neededInventoryItems.Clear();
        PlayCustomSound();
        yield return new WaitForSeconds(1);
        Debug.Log("first item");
        GameController.Instance.Inventory.Add(item);
        GameController.Instance.Inventory.Add(item2);
        deactivateAfterAction = true;

        yield return null;
    }
}

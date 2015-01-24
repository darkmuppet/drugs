using UnityEngine;
using System.Collections;

public class HotSpotVomit : HotSpotAddToInventory {

    public override void OnPerformAction()
    {
        GameController.Instance.Inventory.Add(item);
        // TODO change vomit sprite?
    }
}

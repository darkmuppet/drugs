using UnityEngine;
using System.Collections;

public class HotSpotVomit : HotSpotAddToInventory {

    public override IEnumerator OnPerformAction()
    {
      yield return null;
        GameController.Instance.Inventory.Add(item);
        // TODO change vomit sprite?
    }
}

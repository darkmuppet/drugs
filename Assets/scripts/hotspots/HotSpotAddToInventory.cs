using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HotSpotAddToInventory : HotSpot {

  public GameObject item;

  public override IEnumerator OnPerformAction() {
    yield return null;
    GameController.Instance.Inventory.Add(item);
  }
}


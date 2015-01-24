using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HotSpotAddToInventory : HotSpot {

  public GameObject item;

  public override void OnPerformAction() {
    GameController.Instance.Inventory.Add(item);
  }
}


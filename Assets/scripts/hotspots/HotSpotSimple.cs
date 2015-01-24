using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HotSpotSimple : HotSpot {

  public override void OnPlayerArrived() {
    Debug.Log("Player arrived");
  }
}

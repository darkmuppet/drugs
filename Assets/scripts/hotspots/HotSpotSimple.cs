using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HotSpotSimple : HotSpot {

  public override IEnumerator OnPerformAction() {
    // GameController.Instance.Player.TriggerAnimation("anim");
    yield return new WaitForSeconds(5);

    // TODO: other stuff
  }
}
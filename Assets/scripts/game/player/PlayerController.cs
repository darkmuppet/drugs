using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public float speed = 10;

  private HotSpot CurrentHotSpot { get; set; }

  public void MoveToHotSpot(HotSpot hotSpot, iTween.EaseType easeType = iTween.EaseType.linear) {
    CurrentHotSpot = hotSpot;
    iTween.MoveTo(gameObject, iTween.Hash(
      "path", iTweenPath.GetPath("player_path"),  // TODO: select correct path
      "speed", speed, 
      "easeType", easeType,
      "oncomplete", "OnPathComplete"
      ));
  }

  private void OnPathComplete() {
    // TODO: notify hot spot
    if (CurrentHotSpot != null) {
      CurrentHotSpot.OnPlayerArrived();
    }
  }
}

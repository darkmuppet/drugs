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

    WaypointPathfinder pathFinder = GameController.Instance.RoomRoot.PathFinder;

    List<Vector3> nodes = pathFinder.FindPath(transform.position, hotSpot.playerTarget.position);

    if (nodes.Count == 0) {
      return;
    }

    if (nodes.Count == 1) {
      nodes.Insert(0, transform.position);
    }

    nodes.Add(hotSpot.playerTarget.position);

    iTween.MoveTo(gameObject, iTween.Hash(
      "path", nodes.ToArray(),
      "speed", speed, 
      "easeType", easeType,
      "oncomplete", "OnPathComplete"
      ));

    // TODO: trigger walk animation
  }

  private void OnPathComplete() {
    // TODO: trigger idle animation

    if (CurrentHotSpot != null) {
      CurrentHotSpot.OnPlayerArrived();
    }
  }
}

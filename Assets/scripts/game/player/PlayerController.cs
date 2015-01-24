using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public float speed = 10;

  public float depthScaleFactor = -1.2f;

  public Animator animator;

  private HotSpot CurrentHotSpot { get; set; }

  public void MoveToHotSpot(HotSpot hotSpot, iTween.EaseType easeType = iTween.EaseType.linear) {
    if (CurrentHotSpot == hotSpot) {
      // already on the way
      return;
    }

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
    //animator.SetTrigger("walk");
  }

  private void OnPathComplete() {
    // TODO: trigger idle animation
    //animator.SetTrigger("idle");

    if (CurrentHotSpot != null) {
      CurrentHotSpot.OnPlayerArrived();
    }
  }

  //public void Update() {
  //  Debug.Log(transform.position.z.ToString());
  //}

  public void LateUpdate() {
    Vector3 scale = transform.localScale;
    scale.x = 1.0f - transform.position.z * depthScaleFactor;
    scale.y = 1.0f - transform.position.z * depthScaleFactor;
    transform.localScale = scale;
  }

  public void TriggerAnimation(string name) {
    animator.SetTrigger(name);
  }
}

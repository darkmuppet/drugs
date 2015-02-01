using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public float speed = 10;

  public float animatorSpeedFactor = 0.1f;

  public float depthScaleFactor = -1.2f;

  public Animator animator;

  public Skeleton skeleton;

  private HotSpot CurrentHotSpot { get; set; }

  private Vector3 LastPosition { get; set; }

  private bool LooksRight { get; set; }

  private bool IsWalking { get; set; }

  public void MoveToHotSpot(HotSpot hotSpot, iTween.EaseType easeType = iTween.EaseType.linear) {
      // TODO fix this
    //if (CurrentHotSpot == hotSpot) {
      // already on the way
      //return;
    //}

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

    // trigger walk animation
    animator.SetTrigger("walk");

    // flip orientation
    bool targetIsLeft = (hotSpot.playerTarget.position.x < transform.position.x);
    if (targetIsLeft == true && LooksRight == true) {
      skeleton.FlipHack();
      LooksRight = false;
    } else if(targetIsLeft == false && LooksRight == false) {
      skeleton.FlipHack();
      LooksRight = true;
    }

    IsWalking = true;
  }

  private void OnPathComplete() {
    // trigger idle animation
    animator.SetTrigger("idle");

    if (CurrentHotSpot != null) {
      CurrentHotSpot.OnPlayerArrived();
    }

    IsWalking = false;
    animator.speed = 1;
  }

  //public void Update() {
  //  Debug.Log(transform.position.z.ToString());
  //}

  public void LateUpdate() {
    //Vector3 scale = transform.localScale;
    //scale.x = 1.0f - transform.position.z * depthScaleFactor;
    //scale.y = 1.0f - transform.position.z * depthScaleFactor;
    //transform.localScale = scale;

    if (IsWalking) {
      Vector3 currentPosition = transform.position;
      float diff = Vector3.Distance(currentPosition, LastPosition);
      animator.speed = diff * animatorSpeedFactor;

      LastPosition = currentPosition;
    }
  }

  public void TriggerAnimation(string name) {
    animator.SetTrigger(name);
  }
}

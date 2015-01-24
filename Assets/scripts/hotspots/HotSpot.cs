using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class HotSpot : MonoBehaviour {

  public Transform playerTarget;

  public List<string> neededInventoryItems;

  public bool deactivateAfterAction = true;

  public void OnMouseOver() {
    HighlightHotSpot();
  }

  public void OnMouseUpAsButton() {
    OnHotSpotClicked();
  }

  public void Update() {
    // TODO change highlight button
    if (Input.GetMouseButtonDown(1)) {
      HighlightHotSpot();
    }
  }

  private void HighlightHotSpot() {
    // TODO glow or something
  }

  private void OnHotSpotClicked() {
    GameController.Instance.Player.MoveToHotSpot(this);
  }

  public void OnPlayerArrived() {
    if (neededInventoryItems == null || neededInventoryItems.Count == 0) {
      PerformAction();
    } else {
      bool meetsRequirements = true;
      neededInventoryItems.ForEach(item => {
        if (GameController.Instance.Inventory.Owns(item) == false) {
          meetsRequirements = false;
        }
      });
      if (meetsRequirements) {
        PerformAction();
      }
    }
  }

  private void PerformAction() {
    OnPerformAction();

    if (deactivateAfterAction) {
      GameObject.Destroy(gameObject);
    }
  }

  public abstract void OnPerformAction();
}

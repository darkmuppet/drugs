using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class HotSpot : MonoBehaviour {

  public Transform playerTarget;

  public List<string> neededInventoryItems;

  public bool deactivateAfterAction = true;

  private bool InputLocked { get; set; }

  public void OnMouseOver() {
    if (InputLocked == false) {
      
    }
  }

  public void OnMouseEnter() {
    if (InputLocked == false) {
      GameController.Instance.SetCursorStyle(GameController.CursorStyle.HotSpot);
    }
  }

  public void OnMouseExit() {
    GameController.Instance.SetCursorStyle(GameController.CursorStyle.Default);
  }

  public void OnMouseUpAsButton() {
    if (InputLocked == false) {
      OnHotSpotClicked();
    }
  }

  public void Update() {
    // TODO change highlight button
    if (InputLocked == false) {
      if (Input.GetMouseButtonDown(1)) {
        HighlightHotSpot();
      }
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
        if (meetsRequirements)
        {
            PerformAction();
            neededInventoryItems.ForEach(item =>
            {
                if (GameController.Instance.Inventory.Owns(item) == true)
                {
                    GameController.Instance.Inventory.Remove(item);
                }
            });
        }
        else
        {
            // TODO sigh!
        }
    }
  }

  private void PerformAction() {
    StartCoroutine(PerformActionCoroutine());
  }

  private IEnumerator PerformActionCoroutine() {
    Debug.Log("Performing action");
    InputLocked = true;

    yield return StartCoroutine(OnPerformAction());

    if (deactivateAfterAction) {
      GameObject.Destroy(gameObject);
    }
    InputLocked = false;
    Debug.Log("Action done");
  }

  public abstract IEnumerator OnPerformAction();
}

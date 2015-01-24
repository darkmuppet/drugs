using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameStateLoading : AbstractState {

  public GameStateLoading(string stateName) : base(stateName) { 

  }

  protected override void OnInitialize() {
    
  }

  protected override void OnEnter(object onEnterParams = null) {
    GameController.Instance.StartCoroutine(LoadRoom(onEnterParams as string));
  }

  protected override void OnLeave() {
    
  }

  protected override void OnUpdate() {
    
  }

  private IEnumerator LoadRoom(string sceneName) {
    
    // TODO: fade out

    // delete old room objects
    GameObject goRoomRoot = GameObject.Find(RoomRoot.roomRootName);
    if (goRoomRoot != null) {
      GameObject.Destroy(goRoomRoot);
    }

    yield return Application.LoadLevelAdditiveAsync(sceneName);

    // TODO: fade in

    // find new room root
    goRoomRoot = GameObject.Find(RoomRoot.roomRootName);

    GameController.Instance.ChangeState("GameStatePlaying", goRoomRoot);
  }

}


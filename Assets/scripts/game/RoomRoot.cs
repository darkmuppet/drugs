﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RoomRoot : MonoBehaviour {

  public const string roomRootName = "room_root";

  public RoomLoadingHelper roomLoadingHelper;

  public Transform playerStart;

  private static bool firstLoad = true;

  public iTweenPath playerPath;

  public iTweenPath PlayerPath {
    get {
      return playerPath;
    }
  }

  public void Start() {

#if UNITY_EDITOR
    // check if the game_controller is there and if not, just switch to the main scene
    if (firstLoad == true) {
      firstLoad = false;
      roomLoadingHelper.LoadRoomForDevelopment(Application.loadedLevelName);
    }
#endif

  }
}

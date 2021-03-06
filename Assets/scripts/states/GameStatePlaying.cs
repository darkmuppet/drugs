﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class GameStatePlaying : AbstractState {

  private RoomRoot RoomRoot { get; set; }

  public GameStatePlaying(string stateName) : base(stateName) { 

  }

  protected override void OnInitialize() {
   
  }

  protected override void OnEnter(object onEnterParams = null) {
    RoomRoot = onEnterParams as RoomRoot;

    if (RoomRoot.clearInventory) {
      GameController.Instance.Inventory.Clear();
    }

    if (RoomRoot.spawnPlayer) {
      GameController.Instance.InitializePlayer(RoomRoot);
    }
  }

  protected override void OnLeave() {
   
  }

  protected override void OnUpdate() {

  }
}

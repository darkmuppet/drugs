﻿using UnityEngine;
using System.Collections;

public class GameStateMenu : AbstractState {

  // TODO: make configurable
  private const string startingRoom = "room_0";

  private GameObject GoMenuCamera { get; set; }

  public GameStateMenu(string stateName) : base(stateName) {

  }

  protected override void OnInitialize() {
    GoMenuCamera = GameObject.Find("camera_main");
  }

  protected override void OnEnter(object onEnterParams = null) {
    GoMenuCamera.SetActive(true);
  }

  protected override void OnLeave() {
    GoMenuCamera.SetActive(false);
  }

  protected override void OnUpdate() {
    if (Input.GetMouseButton(0)) {
      GameController.Instance.ChangeState("GameStateLoading", startingRoom);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameController : MonoBehaviour {

  public static string startingRoom = "room_0";

  private static GameController instance;
  public static GameController Instance {
    get {
      return instance;
    }
  }

  private StateMachine StateMachine { get; set; }

  public void Awake() {
    instance = this;
    DontDestroyOnLoad(gameObject);

    List<AbstractState> states = new List<AbstractState>();
    states.Add(new GameStateLoading("GameStateLoading"));
    states.Add(new GameStateMenu("GameStateMenu"));
    states.Add(new GameStatePlaying("GameStatePlaying"));

    StateMachine = StateMachine.Create("state_machine", states, "GameStateMenu");
  }

  public void SwitchToRoom(string sceneName) {
    ChangeState("GameStateLoading", sceneName);
  }

  public void ChangeState(string stateName, object onEnterParams = null) {
    StateMachine.ChangeState(stateName, onEnterParams);
  }

  public void OnGUI() {
    GUILayout.Label("Current state: " + StateMachine.CurrentStateName);
  }

  public void LoadStartingRoom() {
    ChangeState("GameStateLoading", startingRoom);
  }
}


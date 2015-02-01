using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameController : MonoBehaviour {

  public enum CursorStyle {
    Default,
    HotSpot,
  }

  public static string startingRoom = "room_0";

  private static GameController instance;
  public static GameController Instance {
    get {
      return instance;
    }
  }

  public Texture2D textureCursorDefault;
  public Texture2D textureCursorHotSpot;
  public Inventory inventory;

  private StateMachine StateMachine { get; set; }

  public PlayerController Player { get; private set; }

  public Inventory Inventory {
    get {
      return inventory;
    }
  }

  public RoomRoot RoomRoot { get; private set; }

  public void Awake() {
    instance = this;
    DontDestroyOnLoad(gameObject);

    List<AbstractState> states = new List<AbstractState>();
    states.Add(new GameStateLoading("GameStateLoading"));
    states.Add(new GameStateMenu("GameStateMenu"));
    states.Add(new GameStatePlaying("GameStatePlaying"));

    StateMachine = StateMachine.Create("state_machine", states, "GameStateMenu");

    SetCursorStyle(CursorStyle.Default);
  }

  public void SwitchToRoom(string sceneName) {
    ChangeState("GameStateLoading", sceneName);
  }

  public void ChangeState(string stateName, object onEnterParams = null) {
    StateMachine.ChangeState(stateName, onEnterParams);
  }

  public void OnGUI() {
#if UNITY_EDITOR
    GUILayout.Label("Current state: " + StateMachine.CurrentStateName);
#endif
  }

  public void LoadStartingRoom() {
    ChangeState("GameStateLoading", startingRoom);
  }

  public void InitializePlayer(RoomRoot roomRoot) {
    if (Player != null) {
      GameObject.Destroy(Player.gameObject);
    }

    RoomRoot = roomRoot;

    GameObject goPlayer = GameObject.Instantiate(RoomRoot.prefabPlayer, RoomRoot.playerStart.position, RoomRoot.playerStart.rotation) as GameObject;
    Player = goPlayer.GetComponent<PlayerController>();
  }

  public void SetCursorStyle(CursorStyle cursorStyle) {
    switch (cursorStyle) {
      case CursorStyle.HotSpot:
        Cursor.SetCursor(textureCursorHotSpot, Vector2.zero, CursorMode.Auto);
        break;
      default:
        Cursor.SetCursor(textureCursorDefault, Vector2.zero, CursorMode.Auto);
        break;
    }
  }
}


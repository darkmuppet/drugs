using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RoomLoadingHelper : MonoBehaviour {

  private IEnumerator LoadRoomForDevelopmentInternal(string sceneName) {
    if (GameController.Instance == null) {
      Debug.Log("Loading main scene to init game controller...");
      Application.LoadLevel("main");

      while (GameController.Instance == null) {
        yield return null;
      }

      Debug.Log("Switching room for development: " + sceneName);
      GameController.Instance.SwitchToRoom(sceneName);

      Destroy(gameObject);
    }
  }

  public void LoadRoomForDevelopment(string sceneName) {
    DontDestroyOnLoad(gameObject);
    StartCoroutine(LoadRoomForDevelopmentInternal(sceneName));
  }
}

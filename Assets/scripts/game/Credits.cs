using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Credits : MonoBehaviour {

  public float creditsDelay = 10.0f;

  public GameObject goCredits;

  public void Start() {
    goCredits.SetActive(false);
    StartCoroutine(ShowCredits());
  }

  private IEnumerator ShowCredits() {
    yield return new WaitForSeconds(creditsDelay);
    goCredits.SetActive(true);
  }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Inventory {

  private Dictionary<string, GameObject> Items { get; set; }

  public Inventory() {
    Items = new Dictionary<string, GameObject>();
  }

  public bool Owns(string id) {
    return Items.ContainsKey(id);
  }

  public void Add(GameObject item) {
    item.SetActive(false);
    Items[item.name] = item;
  }

  public GameObject Remove(string id) {
    if (Items.ContainsKey(id)) {
      GameObject item = Items[id];
      item.SetActive(true);
      Items.Remove(item.name);
      return item;
    } else {
      return null;
    }
  }

  public void Clear() {
    foreach (GameObject go in Items.Values) {
      GameObject.Destroy(go);
    }
    Items.Clear();
  }
}


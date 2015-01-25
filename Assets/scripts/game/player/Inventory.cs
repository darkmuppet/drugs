using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Inventory {

  private Dictionary<string, GameObject> Items { get; set; }

  private Dictionary<string, Texture> InventoryTextures { get; set; }

  public Inventory() {
    Items = new Dictionary<string, GameObject>();
    InventoryTextures = new Dictionary<string, Texture>();
  }

  public bool Owns(string id) {
    return Items.ContainsKey(id);
  }

  public void Add(GameObject item) {
    item.SetActive(false);
    Items[item.name] = item;

    SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
    if (spriteRenderer != null && spriteRenderer.sprite != null) {
      InventoryTextures[item.name] = spriteRenderer.sprite.texture;
    }
  }

  public GameObject Remove(string id) {
    if (Items.ContainsKey(id)) {
      GameObject item = Items[id];
      item.SetActive(true);
      Items.Remove(item.name);
      InventoryTextures.Remove(item.name);
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
    InventoryTextures.Clear();
  }

  public void OnGUI() {
    float itemWidth = (float)Screen.width * 0.1f;
    float itemHeight = (float)Screen.height * 0.1f;

    Rect rect = new Rect(0, 0, itemWidth, itemHeight);

    int itemNr = 0;
    foreach (Texture texture in InventoryTextures.Values) {
      rect.x = itemWidth * itemNr;
      GUI.Box(rect, "");
      GUI.DrawTexture(rect, texture, ScaleMode.ScaleToFit);
      itemNr++;
    }
  }
}


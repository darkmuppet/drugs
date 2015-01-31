using UnityEngine;
using System.Collections;

public class HotSpotYoghurt : HotSpot {

    public GameObject spoonGameObject;

    public GameObject yoghurtGameObject;

    public Sprite yoghurtNoSpoon;

    public override IEnumerator OnPerformAction()
    {
        SpriteRenderer yoghurtSpriteRenderer = yoghurtGameObject.GetComponent<SpriteRenderer>();
        yoghurtSpriteRenderer.sprite = yoghurtNoSpoon;
        GameController.Instance.Inventory.Add(spoonGameObject);
        yield return null;
    }
}

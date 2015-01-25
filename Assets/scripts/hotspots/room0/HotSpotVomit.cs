using UnityEngine;
using System.Collections;

public class HotSpotVomit : HotSpotAddToInventory
{

    public GameObject vomitGameObject;
    public Sprite vomitNoKey;

    public override IEnumerator OnPerformAction()
    {

        GameController.Instance.Inventory.Add(item);
        SpriteRenderer vomitSpriteRenderer= vomitGameObject.GetComponent<SpriteRenderer>();
        vomitSpriteRenderer.sprite = vomitNoKey;
        yield return null;
        // TODO change vomit sprite?

    }
}

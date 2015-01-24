using UnityEngine;
using System.Collections;

public class HotSpotFridge : HotSpot {

    public GameObject item;
    public GameObject item2;

    private bool nextItem = false;
    private bool destroy = false;

    private void PerformAction()
    {
        OnPerformAction();

        if (deactivateAfterAction && destroy)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public override IEnumerator OnPerformAction()
    {
      
        if (!nextItem)
        {
            GameController.Instance.Inventory.Add(item);
            nextItem = true;
        }
        else
        {
            GameController.Instance.Inventory.Add(item2);
            destroy = true;
        }
        yield return null;
    }
}

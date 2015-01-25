using UnityEngine;
using System.Collections;

public class HotSpotDealer : HotSpot
{

    public GameObject trophyHotSpot;
    private int state;

    public void Awake()
    {
        state = 0;
    }

    public void SetState(int newState)
    {
        state = newState;
    }

    public override IEnumerator OnPerformAction()
    {
        switch (state)
        {
            case 1:
                DealerWantsMoney();
                break;
            case 2:
                DealerGetsHit();
                break;
            case 3:
                DealerWantsFeet();
                break;
            case 4:
                GameObject.Destroy(gameObject);
                break;
        }
        yield return null;
    }

    private void DealerWantsMoney()
    {
        // TODO drugdealer wants money
        trophyHotSpot.SetActive(true);

    }

    private void DealerGetsHit()
    {
        // TODO dealer gets beaten
    }

    private void DealerWantsFeet()
    {
        // TODO dealer wants feet
    }
}

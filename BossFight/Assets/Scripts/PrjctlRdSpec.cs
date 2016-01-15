using UnityEngine;
using System.Collections;

public class PrjctlRdSpec : MonoBehaviour
{

    BlkBrdMngr BlkBrdMngr;

    public bool AreBulletsNear;
    public int TotalBulletsNear;

    // Use this for initialization
    void Start()
    {
        BlkBrdMngr = GetComponent<BlkBrdMngr>();
        TotalBulletsNear = 0;
        AreBulletsNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalBulletsNear <= 0)
            AreBulletsNear = false;
        else
            AreBulletsNear = true;

        // Sometimes bullets near become negative, this is a hard fix.
        if (TotalBulletsNear < 0)
            TotalBulletsNear = 0;

        UpdateBlackBox();
    }

    // Updates BlackBox with Data collected every frame.
    void UpdateBlackBox()
    {
        BlkBrdMngr.WriteBlckBrd.AreBulletsNear = AreBulletsNear;
        BlkBrdMngr.WriteBlckBrd.NumberBulletsNear = TotalBulletsNear;
    }

}

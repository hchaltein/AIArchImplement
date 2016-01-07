using UnityEngine;
using System.Collections;

public class PrjctlRdSpec : MonoBehaviour
{

    AICtrl AiControler;

    public bool AreBulletsNear;
    public int TotalBulletsNear;

    // Use this for initialization
    void Start()
    {
        AiControler = GetComponent<AICtrl>();
        TotalBulletsNear = 0;
        AreBulletsNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalBulletsNear == 0)
            AreBulletsNear = false;
        else
            AreBulletsNear = true;

        UpdateBlackBox();
    }

    // Updates BlackBox with Data collected every frame.
    void UpdateBlackBox()
    {
        AiControler.WriteBlckBrd.AreBulletsNear = AreBulletsNear;
        AiControler.WriteBlckBrd.NumberBulletsNear = TotalBulletsNear;
    }

}

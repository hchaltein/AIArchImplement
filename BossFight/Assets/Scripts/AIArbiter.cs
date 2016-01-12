using UnityEngine;
using System.Collections;

public class AIArbiter : MonoBehaviour
{

    // Component Variables
    BlkBrdMngr BlkBrdMngr;
    AICtrl AICtrl;

    // Class Variables

    // Use this for initialization
    void Start ()
    {
        BlkBrdMngr = GetComponent<BlkBrdMngr>();
        AICtrl = GetComponent<AICtrl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (BlkBrdMngr.ReadBlckBrd.isPlyrLinedUp)
        {
            AICtrl.ShootProj();
        }
	}
}

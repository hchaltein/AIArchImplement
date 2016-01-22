using UnityEngine;
using System.Collections;

public class BossAttackSpec : MonoBehaviour
{
    // Component Variables
    BlkBrdMngr BlkBrdMngr;
    BlackBoard ReadBlackBoard;
    AICtrl AICtrl;

    // Class Variables
    bool CanJump;
    float JumpWaitTime;

    // Use this for initialization
    void Start ()
    {
        // Component References
        BlkBrdMngr = GetComponent<BlkBrdMngr>();
        AICtrl = GetComponent<AICtrl>();

        // Starting Conditions
        CanJump = true;
        JumpWaitTime = 0.5f;

    }
	
	// Update is called once per frame
	void Update ()
    {
        // Gets updated Black Board.
        ReadBlackBoard = BlkBrdMngr.ReadBlckBrd;

        // Shooting behavior
        if (ReadBlackBoard.isPlyrLinedUp && !ReadBlackBoard.AreBulletsNear)
            AICtrl.ShootProj();

        else
        {
            // Tries to Dodge bullets and realign player
            if (CanJump == true)
            {
                AICtrl.Jump();
                CanJump = false;
                StartCoroutine(WaitBetweenJumps());
            }
        }
    }

    IEnumerator WaitBetweenJumps()
    {
        yield return new WaitForSeconds(JumpWaitTime);
        CanJump = true;
    }
}

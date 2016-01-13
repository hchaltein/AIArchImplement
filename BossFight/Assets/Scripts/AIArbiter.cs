using UnityEngine;
using System.Collections;

public enum BossBehavior
{
    Agressive,
    Defensive
}

public class AIArbiter : MonoBehaviour
{

    // Component Variables
    BlkBrdMngr BlkBrdMngr;
    BlackBoard ReadBlackBoard;
    AICtrl AICtrl;

    // Class Variables
    BossBehavior BossBhvr;
    bool CanJump;
    bool MovingToOtherSide;
    float JumpWaitTime;

    // Use this for initialization
    void Start ()
    {
        // Component References
        BlkBrdMngr = GetComponent<BlkBrdMngr>();
        AICtrl = GetComponent<AICtrl>();
        
        // Starting Conditions
        BossBhvr = BossBehavior.Agressive;
        CanJump = true;
        MovingToOtherSide = false;
        JumpWaitTime = 0.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Gets updated Black Board.
        ReadBlackBoard = BlkBrdMngr.ReadBlckBrd;

        // Makes sure Boss is facing player
        FacePlayer();

        // Change Behavior if Health is less than 50%
        if (ReadBlackBoard.BossHP < 0.5f)
            BossBhvr = BossBehavior.Defensive;

        switch (BossBhvr)
        {
            case BossBehavior.Agressive:
                // Shooting behavior
                if (ReadBlackBoard.isPlyrLinedUp)
                    AICtrl.ShootProj();
                else
                {
                    if (CanJump == true)
                    {
                        AICtrl.Jump();
                        CanJump = false;
                        StartCoroutine(WaitBetweenJumps());
                    }
                }

                switch (ReadBlackBoard.PlyrDist)
                {
                    // Get Away from player.
                    case PlayerDistance.TooNear:
                        JumpAway();
                        break;
                        
                    // Ok distance
                    case PlayerDistance.Near:
                        break;

                    // Get Closer to palyer
                    case PlayerDistance.Far:
                        MoveCloser();
                        break;

                    default:
                        break;
                }
                break;
            case BossBehavior.Defensive:
                // Shooting behavior
                if (ReadBlackBoard.isPlyrLinedUp)
                    AICtrl.ShootProj();
                else
                {
                    if (CanJump == true)
                    {
                        AICtrl.Jump();
                        CanJump = false;
                        StartCoroutine(WaitBetweenJumps());
                    }
                }

                switch (ReadBlackBoard.PlyrDist)
                {
                    // Move to the other side of the screen.
                    case PlayerDistance.TooNear:

                        break;

                    // Jump Away from the player
                    case PlayerDistance.Near:
                        JumpAway();
                        break;

                    // Ok distance.
                    case PlayerDistance.Far:
                        break;
                    default:
                        break;
                }

                break;
            default:
                break;
        }

	} // Update

    void FacePlayer()
    {
        // Player is to the left and boss is facing right
        if (ReadBlackBoard.PlyrLoc == PlayerLocation.LeftFromBoss && AICtrl.isFacingRight)
            AICtrl.FaceLeft();

        // Player is to the right and boss is facing left
        else if (ReadBlackBoard.PlyrLoc == PlayerLocation.RightFromBoss && !AICtrl.isFacingRight)
            AICtrl.FaceRight();
    }

    void MoveCloser()
    {
        if (ReadBlackBoard.PlyrLoc == PlayerLocation.LeftFromBoss)
            AICtrl.MoveLeft();
        else if (ReadBlackBoard.PlyrLoc == PlayerLocation.RightFromBoss)
            AICtrl.MoveRight();
    }

    // Get Away from the player by jumping
    void JumpAway()
    {
        if (ReadBlackBoard.PlyrLoc == PlayerLocation.LeftFromBoss)
        {
            AICtrl.Jump();
            AICtrl.MoveRight();
        }
        else if (ReadBlackBoard.PlyrLoc == PlayerLocation.RightFromBoss)
        {
            AICtrl.Jump();
            AICtrl.MoveLeft();
        }
    }

    void MoveToOtherSide(BossLocation Origin)
    {

    }

    IEnumerator WaitBetweenJumps()
    {
        yield return new WaitForSeconds(JumpWaitTime);
        CanJump = true;
    }
}

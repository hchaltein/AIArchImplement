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
    public BossBehavior BossBhvr;
    bool CanJump;
    public bool MovingToOtherSide;
    float JumpWaitTime;

    public BossLocation Destination;

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

        // Part of the move tot he other side loop
        if (MovingToOtherSide)
            MoveToOtherSide(ReadBlackBoard.BossLoc);
        
        // Makes sure Boss is facing player
        FacePlayer();

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

        // Change Positioning Behavior if Health is less than 50%
        if (ReadBlackBoard.BossHP < 0.5f)
            BossBhvr = BossBehavior.Defensive;

        // Positioning Behavior:
        switch (BossBhvr)
        {
            case BossBehavior.Agressive:

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
                switch (ReadBlackBoard.PlyrDist)
                {
                    // Move to the other side of the screen.
                    case PlayerDistance.TooNear:
                        MoveToOtherSide(ReadBlackBoard.BossLoc);
                        break;

                    // Jump Away from the player
                    case PlayerDistance.Near:
                        MoveToOtherSide(ReadBlackBoard.BossLoc);
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
       // Set Up Moving to other side status.
        if (MovingToOtherSide == false)
        {
            // Set Up Destination
            MovingToOtherSide = true;
            // If on the Left side, go right.
            if (Origin == BossLocation.LeftSide)
                Destination = BossLocation.RightSide;
            
            // If on center or right side, go left!
            else
                Destination = BossLocation.LeftSide;
            return;
        }
        else
        {
            if (Origin != Destination)
            {
                // Go right
                if (Destination == BossLocation.RightSide)
                    AICtrl.MoveRight();
                
                // Go left
                else if (Destination == BossLocation.LeftSide)
                    AICtrl.MoveLeft();
                // Jump in either option
                AICtrl.Jump();
            }
            // Boss movement has finished.
            else
                MovingToOtherSide = false;
        }
    }

    IEnumerator WaitBetweenJumps()
    {
        yield return new WaitForSeconds(JumpWaitTime);
        CanJump = true;
    }
}

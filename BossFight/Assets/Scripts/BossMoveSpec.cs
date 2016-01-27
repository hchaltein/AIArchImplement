using UnityEngine;
using System.Collections;

// Specialist responsible for the Boss Movement
public class BossMoveSpec : MonoBehaviour
{
    // Component Variables
    BlkBrdMngr BlkBrdMngr;
    BlackBoard ReadBlackBoard;
    AICtrl AICtrl;

    // Class Variables
    public bool MovingToOtherSide;
    BossLocation BossScreenSideDest;

    // Use this for initialization
    void Start ()
    {
        // Component References
        BlkBrdMngr = GetComponent<BlkBrdMngr>();
        AICtrl = GetComponent<AICtrl>();

        // Starting Conditions
        MovingToOtherSide = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Gets updated Black Board.
        ReadBlackBoard = BlkBrdMngr.ReadBlckBrd;
        
        // Part of the move to the other side loop
        if (MovingToOtherSide)
            MoveToOtherSide(ReadBlackBoard.CurBossLoc);
        
        // Makes sure Boss is ALWAYS facing player
        FacePlayer();

        // If Specialist is active, act.
        if (ReadBlackBoard.ActSpec == ActionSpecialists.MoveSpec)
            MoveLogic();

        // Updates Write BlackBoard with MovingToOtherSide bool
        BlkBrdMngr.WriteBlckBrd.isMovingToOtherSide = MovingToOtherSide;

    } //Update

    // Positioning Behavior:
    void MoveLogic()
    {
        switch (ReadBlackBoard.BossBhvr)
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
                        Debug.Log("Invalid Player Distance");
                        break;
                }
                break;

            case BossBehavior.Defensive:
                switch (ReadBlackBoard.PlyrDist)
                {
                    // Move to the other side of the screen.
                    case PlayerDistance.TooNear:
                        MoveToOtherSide(ReadBlackBoard.CurBossLoc);
                        break;

                    // Jump Away from the player
                    case PlayerDistance.Near:
                        MoveToOtherSide(ReadBlackBoard.CurBossLoc);
                        break;

                    // Ok distance.
                    case PlayerDistance.Far:
                        break;

                    default:
                        Debug.Log("Invalid Player Distance");
                        break;
                }
                break;
            default:
                Debug.Log("Invalid Bosss Behavior");
                break;
        }
    }

    //Function that rotates Boss towards player.
    void FacePlayer()
    {
        // Player is to the left and boss is facing right
        if (ReadBlackBoard.PlyrLoc == PlayerLocation.LeftFromBoss && AICtrl.isFacingRight)
            AICtrl.FaceLeft();

        // Player is to the right and boss is facing left
        else if (ReadBlackBoard.PlyrLoc == PlayerLocation.RightFromBoss && !AICtrl.isFacingRight)
            AICtrl.FaceRight();
    }

    //Moves Boss closer to Player by walking
    void MoveCloser()
    {
        // Player is to the left
        if (ReadBlackBoard.PlyrLoc == PlayerLocation.LeftFromBoss)
            AICtrl.MoveLeft();
        // Player is to the right
        else if (ReadBlackBoard.PlyrLoc == PlayerLocation.RightFromBoss)
            AICtrl.MoveRight();
    }

    // Makes Boss get away from the Player by jumping
    void JumpAway()
    {
        //Player is to the left
        if (ReadBlackBoard.PlyrLoc == PlayerLocation.LeftFromBoss)
        {
            AICtrl.Jump();
            AICtrl.MoveRight();
        }
        //Player is to the Right
        else if (ReadBlackBoard.PlyrLoc == PlayerLocation.RightFromBoss)
        {
            AICtrl.Jump();
            AICtrl.MoveLeft();
        }
    }

    // Moves Boss from one side of the Screen to the other by jumping. Part of this function is executed on Update to ensure it ends.
    void MoveToOtherSide(BossLocation Origin)
    {
        // Set Up Moving to other side status.
        if (MovingToOtherSide == false)
        {
            // Set Up Destination
            MovingToOtherSide = true;

            // If on the left side or on center and player to the left, go right!
            if (Origin == BossLocation.LeftSide || (Origin == BossLocation.Center && ReadBlackBoard.PlyrLoc == PlayerLocation.LeftFromBoss))
                BossScreenSideDest = BossLocation.RightSide;

            // If on the right side or on center and player to the right, go right!
            else if (Origin == BossLocation.RightSide || (Origin == BossLocation.Center && ReadBlackBoard.PlyrLoc == PlayerLocation.RightFromBoss))
                BossScreenSideDest = BossLocation.LeftSide;
            
            // Updates Destination to BlackBoard.
            BlkBrdMngr.WriteBlckBrd.DestBossLoc = BossScreenSideDest;
            return;
        }
        
        // Already moving to other side so continue moving.
        else
        {
            // Are we there yet?
            if (Origin != BossScreenSideDest)
            {
                // If going right, keep going.
                if (BossScreenSideDest == BossLocation.RightSide)
                    AICtrl.MoveRight();

                // If going left, keep going.
                else if (BossScreenSideDest == BossLocation.LeftSide)
                    AICtrl.MoveLeft();

                // Jump in either option
                AICtrl.Jump();
            }

            // Boss movement has finished.
            else
                MovingToOtherSide = false;
        }
    }

}

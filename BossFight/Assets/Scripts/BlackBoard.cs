using UnityEngine;
using System.Collections;

// blackBoard Object that contains all information on the scene
public class BlackBoard
{
    // Transforms
    public Transform BossTransform;
    public Transform PlyrTransform;

    //Current Active Specialist
    ActionSpecialists ActSpec;
    PassiveSpecialists PasSpec;

    // Health
    public float PlyrHP;
    public float BossHP;

    //Boss Variables
    public BossBehavior BossBhvr;

    // Distance Variables
    public BossLocation CurBossLoc;
    public BossLocation DestBossLoc;
    public PlayerLocation PlyrLoc;
    public PlayerDistance PlyrDist;
    public bool isPlyrLinedUp;
    public bool isMovingToOtherSide;

    // Projectile Variables
    public bool AreBulletsNear;
    public int NumberBulletsNear;
    
    // Constructor - Assume that Boss and Player are at Starting Positions.
    public BlackBoard()
    {
        // Transforms
        BossTransform = null;
        PlyrTransform = null;

        // Health
        PlyrHP = 1.0f;
        BossHP = 1.0f;

        //Boss Variables
        BossBhvr = BossBehavior.Agressive;

        // Distance Variables
        CurBossLoc = BossLocation.RightSide;
        PlyrLoc = PlayerLocation.LeftFromBoss;
        PlyrDist = PlayerDistance.Far;
        isPlyrLinedUp = false;

        // Projectile Variables
        AreBulletsNear = false;
        NumberBulletsNear = 0;
    }
}

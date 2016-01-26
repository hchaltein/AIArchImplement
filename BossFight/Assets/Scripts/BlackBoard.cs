using UnityEngine;
using System.Collections;

// blackBoard Object that contains all information on the scene
public class BlackBoard
{
    //Transforms
    public Transform BossTransform;
    public Transform PlyrTransform;

    //Specialist
    public ActionSpecialists ActSpec;
    public PassiveSpecialists PasSpec;

    // Health
    public float PlyrHP;
    public float BossHP;

    //Boss Behavior Spec Variables
    public BossBehavior BossBhvr;

    // Distance Spec Variables
    public BossLocation CurBossLoc;
    public BossLocation DestBossLoc;
    public PlayerLocation PlyrLoc;
    public PlayerDistance PlyrDist;
    public bool isPlyrLinedUp;
    public bool isMovingToOtherSide;
    public bool isAtSafeDistance;


    // Projectile Spec Variables
    public bool AreBulletsNear;
    public int NumberBulletsNear;
    
    // Constructor - Assume that Boss and Player are at Starting Positions.
    public BlackBoard()
    {
        // Transforms
        BossTransform = null;
        PlyrTransform = null;

        //Current Active Specialist
        ActSpec = ActionSpecialists.AttackSpec;
        PasSpec = PassiveSpecialists.DistanceSpec;


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

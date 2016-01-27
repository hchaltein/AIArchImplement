using UnityEngine;
using System.Collections;

// BlackBoard class that contains all information on the scene
public class BlackBoard
{
    //Transforms
    public Transform BossTransform;
    public Transform PlyrTransform;

    // Health
    public float PlyrHP;
    public float BossHP;
    
    //Specialist
    public ActionSpecialists ActSpec;
    public PassiveSpecialists PasSpec;

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
        
        // Health
        PlyrHP = 1.0f;
        BossHP = 1.0f;

        //Current Active Specialist
        ActSpec = ActionSpecialists.AttackSpec;
        PasSpec = PassiveSpecialists.DistanceSpec;

        //Boss Variables
        BossBhvr = BossBehavior.Agressive;

        // Distance Variables
        CurBossLoc = BossLocation.RightSide;
        PlyrLoc = PlayerLocation.LeftFromBoss;
        DestBossLoc = BossLocation.RightSide;
        PlyrDist = PlayerDistance.Far;
        isMovingToOtherSide = false;
        isAtSafeDistance = false;
        isPlyrLinedUp = false;

        // Projectile Variables
        AreBulletsNear = false;
        NumberBulletsNear = 0;

}
}

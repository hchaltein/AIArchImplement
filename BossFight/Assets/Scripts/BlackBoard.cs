using UnityEngine;
using System.Collections;

// blackBoard Object that contains all information on the scene
public class BlackBoard
{
    // Transforms
    public Transform BossTransform;
    public Transform PlyrTransform;

    // Health
    public float PlyrHP;
    public float BossHP;

    // Distance Variables
    public BossLocation BossLoc;
    public PlayerLocation PlyrLoc;
    public PlayerDistance PlyrDist;
    public bool isPlyrLinedUp;

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

        // Distance Variables
        BossLoc = BossLocation.RightSide;
        PlyrLoc = PlayerLocation.LeftFromBoss;
        PlyrDist = PlayerDistance.Far;
        isPlyrLinedUp = false;

        // Projectile Variables
        AreBulletsNear = false;
        NumberBulletsNear = 0;
}

    /*
    public BlackBoard(Transform _BossTransform, Transform _PlyrTransform, float _PlyrHP, float _BossHP)
    {
        // Transforms
        BossTransform = _BossTransform;
        PlyrTransform = _PlyrTransform;

        // Health
        PlyrHP = _PlyrHP;
        BossHP = _BossHP;
    }
    */
}

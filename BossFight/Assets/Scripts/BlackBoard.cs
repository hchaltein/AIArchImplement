using UnityEngine;
using System.Collections;

// blackBoard Object that contains all information on the scene
public class BlackBoard
{
    // Transforms
    public Transform BossTransform;
    public Transform PlyrTransform;

    // Health
    float PlyrHP;
    float BossHP;

    // Distance Variables
    public BossLocation BossLoc;
    public PlayerLocation PlyrLoc;
    public PlayerDistance PlyrDist;

    // Projectile Variables
    public bool AreBulletsNear;
    public int NumberBulletsNear;

    // Method Calls

    // Constructor
    public BlackBoard()
    {
        // Transforms
        BossTransform = null;
        PlyrTransform = null;

        // Health
        PlyrHP = 100f;
        BossHP = 100f;

    }

    public BlackBoard(Transform _BossTransform, Transform _PlyrTransform, float _PlyrHP, float _BossHP)
    {
        // Transforms
        BossTransform = _BossTransform;
        PlyrTransform = _PlyrTransform;

        // Health
        PlyrHP = _PlyrHP;
        BossHP = _BossHP;
    }
}

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

    // Distance to points of interest
    public float DistToLeftWall;
    public float DistToRighttWall;
    public float DistToPlayer;

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

        // Distance to points of interest
        DistToLeftWall = 0.0f;
        DistToRighttWall = 0.0f;
        DistToPlayer = 0.0f;
    }

    public BlackBoard(Transform _BossTransform, Transform _PlyrTransform, float _PlyrHP, float _BossHP,
                        float _DistToLeftWall, float _DistToRighttWall, float DistToPlayer)
    {
        // Transforms
        BossTransform = _BossTransform;
        PlyrTransform = _PlyrTransform;

        // Health
        PlyrHP = _PlyrHP;
        BossHP = _BossHP;

        // Distance to points of interest
        DistToLeftWall = _DistToLeftWall;
        DistToRighttWall = _DistToRighttWall;
    }
}

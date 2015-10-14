using UnityEngine;
using System.Collections;

// blackBoard Object that contains all information on the scene
public class BlackBoard
{
    // Transforms
    Transform BossTransform;
    Transform PlyrTransform;

    // Health
    float PlyrHP;
    float BossHP;

    // Distance to points of interest
    Vector3 DistToLeftWall;
    Vector3 DistToRighttWall;
    Vector3 DistToPlayer;


    // Method Calls
    // constructor
    public BlackBoard(Transform _BossTransform, Transform _PlyrTransform, float _PlyrHP, float _BossHP, 
                        Vector3 _DistToLeftWall, Vector3 _DistToRighttWall, Vector3 DistToPlayer)
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

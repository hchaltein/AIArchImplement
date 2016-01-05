using UnityEngine;
using System.Collections;

// Distance Enumerators
public enum BossLocation
{
    RightSide,
    Center,
    LeftSide
}

public enum PlayerLocation
{
    RightFromBoss,
    LeftFromBoss
}

public enum PlayerDistance
{
    Near,
    Far
}

public class DistRdSpec : MonoBehaviour
{
    AICtrl AiControler;
    Transform BossTransform;

    public Transform PlyrTransform;
    public Transform RightWallTransform;
    public Transform LeftWallTransform;

    BossLocation BossLoc;
    PlayerLocation PlyrLoc;
    PlayerDistance PlyrDist;

    public void Awake()
    {
        AiControler = GetComponent<AICtrl>();
        BossTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        ReadWallData();
        ReadPlayerData();
        
        UpdateBlackBox();
    }

    void UpdateBlackBox()
    {
        AiControler.WriteBlckBrd.PlyrTransform = PlyrTransform;
        AiControler.WriteBlckBrd.BossTransform = BossTransform;
        AiControler.WriteBlckBrd.BossLoc = BossLoc;
        AiControler.WriteBlckBrd.PlyrLoc = PlyrLoc;
        AiControler.WriteBlckBrd.PlyrDist = PlyrDist;
    }

    void ReadWallData()
    {
        float DistToRightWall;
        float DistToLeftWall;
        
        // Read Right Wall Data.
        DistToRightWall = Mathf.Abs((RightWallTransform.position.x - BossTransform.position.x));

        // Read Left Wall Data.
        DistToLeftWall = Mathf.Abs((LeftWallTransform.position.x - BossTransform.position.x));

        // Boss is on center of screen
        if (Mathf.Abs(DistToRightWall - DistToLeftWall) < 3.0f)
            BossLoc = BossLocation.Center;
        
        // Boss is on the right side of screen
        else if(DistToRightWall < DistToLeftWall)
            BossLoc = BossLocation.RightSide;
        
        // Boss is on the Leftside of screen
        else
            BossLoc = BossLocation.LeftSide;
    }

    void ReadPlayerData()
    {
        float BossPosX = BossTransform.position.x;
        float PlyrPosX = PlyrTransform.position.x;
        float DistToPlayer = Mathf.Abs(BossPosX - PlyrPosX);

        // Calculate relative distance of Player from Boss.
        if (DistToPlayer < 4)
            PlyrDist = PlayerDistance.Near;
        else if (DistToPlayer > 4.5 )
            PlyrDist = PlayerDistance.Far;

        // Calculate which side from the boss the player is.
        if (BossPosX > PlyrPosX)
            PlyrLoc = PlayerLocation.LeftFromBoss;
        else
            PlyrLoc = PlayerLocation.RightFromBoss;
    }
}

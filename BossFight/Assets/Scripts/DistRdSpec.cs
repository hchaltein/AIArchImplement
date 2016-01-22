using UnityEngine;
using System.Collections;

// Distance Enumerators
public enum BossLocation
{
    RightSide,
    LeftSide,
    Center
}

public enum PlayerLocation
{
    RightFromBoss,
    LeftFromBoss
}

public enum PlayerDistance
{
    Near,
    Far,
    TooNear
}

public class DistRdSpec : MonoBehaviour
{
    BlkBrdMngr BlkBrdMngr;
    Transform BossTransform;

    public Transform PlyrTransform;
    public Transform RightWallTransform;
    public Transform LeftWallTransform;

    BossLocation CurrentBossLoc;
    PlayerLocation PlyrLoc;
    PlayerDistance PlyrDist;

    public bool isPlyrLinedUp;
    [SerializeField]
    [Range(4,15)]
    float NearDistance = 7.5f;

    float TooNearDistance = 3.0f;

    RaycastHit TargetInfo;

    public void Awake()
    {
        BlkBrdMngr = GetComponent<BlkBrdMngr>();
        BossTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        ReadWallData();
        ReadPlayerData();
        
        UpdateBlackBox();

        // Checks if player is lined up with boss.
        if (Physics.Raycast(BossTransform.position, BossTransform.forward, out TargetInfo))
        {
            if (TargetInfo.transform.tag == "Player")
                isPlyrLinedUp = true;
            else
                isPlyrLinedUp = false;
        }
    }

    // Updates BlackBox with Data collected every frame.
    void UpdateBlackBox()
    {
        BlkBrdMngr.WriteBlckBrd.PlyrTransform = PlyrTransform;
        BlkBrdMngr.WriteBlckBrd.BossTransform = BossTransform;
        BlkBrdMngr.WriteBlckBrd.CurBossLoc = CurrentBossLoc;
        BlkBrdMngr.WriteBlckBrd.PlyrLoc = PlyrLoc;
        BlkBrdMngr.WriteBlckBrd.PlyrDist = PlyrDist;

        BlkBrdMngr.WriteBlckBrd.isPlyrLinedUp= isPlyrLinedUp;
    }

    void ReadWallData()
    {
        float DistToRightWall;
        float DistToLeftWall;
        
        // Read Right Wall Data.
        DistToRightWall = Mathf.Abs((RightWallTransform.position.x - BossTransform.position.x));

        // Read Left Wall Data.
        DistToLeftWall = Mathf.Abs((LeftWallTransform.position.x - BossTransform.position.x));

        if (Mathf.Abs(DistToRightWall - DistToLeftWall) < 18.0f)
            CurrentBossLoc = BossLocation.Center;

        // Boss is on the right side of screen
        else if(DistToRightWall < DistToLeftWall)
            CurrentBossLoc = BossLocation.RightSide;

        // Boss is on the Leftside of screen
        else
            CurrentBossLoc = BossLocation.LeftSide;
    }

    void ReadPlayerData()
    {
        float BossPosX = BossTransform.position.x;
        float PlyrPosX = PlyrTransform.position.x;
        float DistToPlayer = Mathf.Abs(BossPosX - PlyrPosX);

        // Calculate relative distance of Player from Boss.

        if (DistToPlayer <= TooNearDistance)
        {
            PlyrDist = PlayerDistance.TooNear;
        }
        else if (DistToPlayer <= NearDistance)
            PlyrDist = PlayerDistance.Near;
        else if (DistToPlayer > NearDistance + 0.5)
            PlyrDist = PlayerDistance.Far;

        // Calculate which side from the boss the player is.
        if (BossPosX > PlyrPosX)
            PlyrLoc = PlayerLocation.LeftFromBoss;
        else
            PlyrLoc = PlayerLocation.RightFromBoss;
    }
}

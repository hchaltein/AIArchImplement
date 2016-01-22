using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Players Objs
    public GameObject BossObj;
    public GameObject PlyrObj;

    BlkBrdMngr BlkBrdMngr;
    BlackBoard ReadBlackBoard;
    AIArbiter AIArbtr;

    //Main UI
    public Image PlayerHP;
    public Image BossHp;

    //Debug UI 
    public GameObject DebugTxtsObj;

    //Distance Stats
    public Text BossBhvrLbl;
    public Text isBossMoveScreenLbl;
    public Text BossDestLbl;

    //Distance Stats
    public Text BossLocLbl;
    public Text PlyrLocLbl;
    public Text PlyrDistLbl;
    public Text FacingPlayer;
    
    // Bullets Stats
    public Text AreBulletsNearLbl;
    public Text TotalBulletsNearLbl;

    bool DebugText = false;

    // Use this for initialization
    void Start ()
    {
        // Deactivate Debug Text
        DebugTxtsObj.SetActive(DebugText);

        BlkBrdMngr = BossObj.GetComponent<BlkBrdMngr>();
        AIArbtr = BossObj.GetComponent<AIArbiter>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Gets updated Black Board.
        ReadBlackBoard = BlkBrdMngr.ReadBlckBrd;

        // Enables Debug Interface
        if (Input.GetKeyDown(KeyCode.Period))
        {
            DebugText = !DebugText;
            DebugTxtsObj.SetActive(DebugText);
        }
        
        // Only try to update debug variables if Debug Interface is enabled.
        if(DebugText)
        {
            #region Boss Behavior Variables
            BossBhvrLbl.text = ReadBlackBoard.BossBhvr.ToString();
            BossDestLbl.text = ReadBlackBoard.DestBossLoc.ToString();

            if (ReadBlackBoard.isMovingToOtherSide)
                isBossMoveScreenLbl.text = "Going to other side!";
            else
                isBossMoveScreenLbl.text = "Not going to other side!";

            #endregion

            #region Distance Variables
            BossLocLbl.text = ReadBlackBoard.CurBossLoc.ToString();
            PlyrLocLbl.text = ReadBlackBoard.PlyrLoc.ToString();
            PlyrDistLbl.text = ReadBlackBoard.PlyrDist.ToString();
            if (ReadBlackBoard.isPlyrLinedUp)
                FacingPlayer.text = "Player Lined Up!";
            else
                FacingPlayer.text = "Player Not Lined Up!";
            #endregion

            #region Bullet Variables
            if (ReadBlackBoard.AreBulletsNear)
                AreBulletsNearLbl.text = "Bullets Are Near";
            else
                AreBulletsNearLbl.text = "Bullets Are Not Near";
            TotalBulletsNearLbl.text = ReadBlackBoard.NumberBulletsNear.ToString();
            #endregion
        }

        // Update HealthBars:
        BossHp.fillAmount = ReadBlackBoard.BossHP;
        PlayerHP.fillAmount = ReadBlackBoard.PlyrHP;

    }
}

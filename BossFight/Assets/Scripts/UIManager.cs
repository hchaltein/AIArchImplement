using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Players Objs
    public GameObject BossObj;
    public GameObject PlyrObj;

    BlkBrdMngr BlkBrdMngr;
    BlackBoard ReadBlackBoard;
    
    //Main UI
    public Image PlayerHP;
    public Image BossHp;
    
    //Debug UI 
    public GameObject DebugTxtsObj;
    bool DebugText = false;

    //Distance Stats
    public Text BossLocLbl;
    public Text PlyrLocLbl;
    public Text PlyrDistLbl;
    public Text SafeDistanceLbl;
    public Text isBossMoveScreenLbl;
    public Text BossDestLbl;
    public Text FacingPlayerLbl;

    //Behavior Variables
    public Text BossBhvrLbl;

    // Bullets Stats
    public Text AreBulletsNearLbl;
    public Text TotalBulletsNearLbl;

    //Current Active Specialist
    public Text ActSpecLbl;
    public Text PasSpecLbl;

    // Use this for initialization
    void Start ()
    {
        // Deactivate Debug Text
        DebugTxtsObj.SetActive(DebugText);

        BlkBrdMngr = BossObj.GetComponent<BlkBrdMngr>();
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
            
            #region Distance Variables
            BossLocLbl.text = ReadBlackBoard.CurBossLoc.ToString();
            PlyrLocLbl.text = ReadBlackBoard.PlyrLoc.ToString();
            PlyrDistLbl.text = ReadBlackBoard.PlyrDist.ToString();

            if (ReadBlackBoard.isAtSafeDistance)
                SafeDistanceLbl.text = "Safe Distance!";
            else
                SafeDistanceLbl.text = "Not Safe Distance!";


            if (ReadBlackBoard.isMovingToOtherSide)
                isBossMoveScreenLbl.text = "Going to other side!";
            else
                isBossMoveScreenLbl.text = "Not going to other side!";

            BossDestLbl.text = ReadBlackBoard.DestBossLoc.ToString();

            if (ReadBlackBoard.isPlyrLinedUp)
                FacingPlayerLbl.text = "Player Lined Up!";
            else
                FacingPlayerLbl.text = "Player Not Lined Up!";
            #endregion

            #region Boss Behavior Variables
            BossBhvrLbl.text = ReadBlackBoard.BossBhvr.ToString();
            #endregion

            #region Bullet Variables
            if (ReadBlackBoard.AreBulletsNear)
                AreBulletsNearLbl.text = "Bullets Are Near";
            else
                AreBulletsNearLbl.text = "Bullets Are Not Near";
            TotalBulletsNearLbl.text = ReadBlackBoard.NumberBulletsNear.ToString();
            #endregion

            #region Specialists
            ActSpecLbl.text = ReadBlackBoard.ActSpec.ToString();
            PasSpecLbl.text = ReadBlackBoard.PasSpec.ToString();
            #endregion

        }

        // Update HealthBars:
        BossHp.fillAmount = ReadBlackBoard.BossHP;
        PlayerHP.fillAmount = ReadBlackBoard.PlyrHP;

    }
}

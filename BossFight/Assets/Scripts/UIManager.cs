using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Players Objs
    public GameObject BossObj;
    public GameObject PlyrObj;

    BlkBrdMngr BlkBrdMngr;
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
        if (Input.GetKeyDown(KeyCode.Period))
        {
            DebugText = !DebugText;
            DebugTxtsObj.SetActive(DebugText);
        }
        
        // Only try to update debug variables if Debug Text is enabled.
        if(DebugText)
        {
            #region Boss Behavior Variables
            BossBhvrLbl.text = AIArbtr.BossBhvr.ToString();
            BossDestLbl.text = AIArbtr.Destination.ToString();

            if (AIArbtr.MovingToOtherSide)
                isBossMoveScreenLbl.text = "Going to other side!";
            else
                isBossMoveScreenLbl.text = "Not going to other side!";

            #endregion

            #region Distance Variables
            BossLocLbl.text = BlkBrdMngr.ReadBlckBrd.BossLoc.ToString();
            PlyrLocLbl.text = BlkBrdMngr.ReadBlckBrd.PlyrLoc.ToString();
            PlyrDistLbl.text = BlkBrdMngr.ReadBlckBrd.PlyrDist.ToString();
            if (BlkBrdMngr.ReadBlckBrd.isPlyrLinedUp)
                FacingPlayer.text = "Player Lined Up!";
            else
                FacingPlayer.text = "Player Not Lined Up!";
            #endregion

            #region Bullet Variables

            if (BlkBrdMngr.ReadBlckBrd.AreBulletsNear)
                AreBulletsNearLbl.text = "Bullets Are Near";
            else
                AreBulletsNearLbl.text = "Bullets Are Not Near";
            TotalBulletsNearLbl.text = BlkBrdMngr.ReadBlckBrd.NumberBulletsNear.ToString();
            #endregion
        }

        // Update HealthBars:
        BossHp.fillAmount = BlkBrdMngr.ReadBlckBrd.BossHP;
        PlayerHP.fillAmount = BlkBrdMngr.ReadBlckBrd.PlyrHP;

    }
}

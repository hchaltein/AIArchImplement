using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject BossObj;
    public GameObject PlyrObj;

    AICtrl AICtrl;

    public GameObject DebugTxtsObj;

    public Text BossLocLbl;
    public Text PlyrLocLbl;
    public Text PlyrDistLbl;

    bool DebugText = false;

    // Use this for initialization
    void Start ()
    {
        // Deactivate Debug Text
        DebugTxtsObj.SetActive(DebugText);

        AICtrl = BossObj.GetComponent<AICtrl>();
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
            #region Distance Variables
            BossLocLbl.text = AICtrl.ReadBlckBrd.BossLoc.ToString();
            PlyrLocLbl.text = AICtrl.ReadBlckBrd.PlyrLoc.ToString();
            PlyrDistLbl.text = AICtrl.ReadBlckBrd.PlyrDist.ToString();
            #endregion
        }
    }
}

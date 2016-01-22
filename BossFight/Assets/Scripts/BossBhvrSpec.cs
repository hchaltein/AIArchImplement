using UnityEngine;
using System.Collections;

public enum BossBehavior
{
    Agressive,
    Defensive
}

// Specialist that changes the boss behavior based on the Boss current HP.
public class BossBhvrSpec : MonoBehaviour
{
    // Component Variables
    BlkBrdMngr BlkBrdMngr;
    BlackBoard ReadBlackBoard;

    // Class Variables

    // Use this for initialization
    void Start ()
    {
        // Component References
        BlkBrdMngr = GetComponent<BlkBrdMngr>();

        // Starting Conditions:
        ReadBlackBoard = BlkBrdMngr.ReadBlckBrd;
        BlkBrdMngr.WriteBlckBrd.BossBhvr = BossBehavior.Agressive;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Update Reac Black Board.
        ReadBlackBoard = BlkBrdMngr.ReadBlckBrd;

        // Change Behavior if Health is less than 50%
        if (ReadBlackBoard.BossHP < 0.5f)
            BlkBrdMngr.WriteBlckBrd.BossBhvr = BossBehavior.Defensive;
    }
}

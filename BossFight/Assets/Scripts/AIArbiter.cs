using UnityEngine;
using System.Collections;

public enum ActionSpecialists
{
    AttackSpec,
    MoveSpec
}

public enum PassiveSpecialists
{
    BehaviorSpec,
    DistanceSpec,
    BulletSpec
}

public class AIArbiter : MonoBehaviour
{
    // Component Variables
    BlkBrdMngr BlkBrdMngr;
    BlackBoard ReadBlackBoard;

    // Class Variables
    ActionSpecialists CurActSpec;
    PassiveSpecialists CurPasSpec;

    // Use this for initialization
    void Start ()
    {
        // Component References
        BlkBrdMngr = GetComponent<BlkBrdMngr>();
        
    }
	
	// Update is called once per frame
    void Update()
    {
        // Gets updated Black Board.
        ReadBlackBoard = BlkBrdMngr.ReadBlckBrd;

        // Decides which specialist gets to act.
        SelectPassiveSpec();
        SelectActiveSpec();


	} // Update

    // Implement the Selection process for the Passive Specialist
    void SelectPassiveSpec()
    {
        switch (CurPasSpec)
        {
            case PassiveSpecialists.BehaviorSpec:
                CurPasSpec = PassiveSpecialists.DistanceSpec;
                break;

            case PassiveSpecialists.DistanceSpec:
                CurPasSpec = PassiveSpecialists.BulletSpec;
                break;

            case PassiveSpecialists.BulletSpec:
                CurPasSpec = PassiveSpecialists.BehaviorSpec;
                break;

            default:
                CurPasSpec = PassiveSpecialists.DistanceSpec;
                break;
        }

        // Update Passive Specialist to BlackBoard
        BlkBrdMngr.WriteBlckBrd.PasSpec = CurPasSpec;
    }
    // Implement the Selection process for the ActiveSpecialist
    void SelectActiveSpec()
    {
        if (ReadBlackBoard.isAtSafeDistance)
            CurActSpec = ActionSpecialists.AttackSpec;
        else
            CurActSpec = ActionSpecialists.AttackSpec;

        // Update Passive Specialist to BlackBoard
        BlkBrdMngr.WriteBlckBrd.ActSpec= CurActSpec;
    }
}

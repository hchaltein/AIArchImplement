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


	} // Update

}

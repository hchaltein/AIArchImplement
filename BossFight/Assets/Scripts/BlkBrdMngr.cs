using UnityEngine;
using System.Collections;

// This scripts has and manages the Black Board.
public class BlkBrdMngr : MonoBehaviour {

    // Black Boards: One being to be read and another to be written this frame.
    public BlackBoard ReadBlckBrd;
    public BlackBoard WriteBlckBrd;


    // Use this for initialization
    void Start ()
    {
        // Instantiate the BBoard
        ReadBlckBrd = new BlackBoard();
        WriteBlckBrd = new BlackBoard();
    }

    // This is called once per frame, after the Update function of every object
    void LateUpdate()
    {
        // Update the Read black board with all the information that was read on this frame
        ReadBlckBrd = WriteBlckBrd;
    }
}

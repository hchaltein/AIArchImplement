using UnityEngine;
using System.Collections;

public class AICtrl : MonoBehaviour
{
    BlackBoard CurBBoard;
    BlackBoard NextBBoard;

    float BossHP = 100.0f;

	// Use this for initialization
	void Start ()
    {
        // Get initial information from Specialists
        
        // Instantiate the BBoard

        // 
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // This is called once per frame, after the Update function of every object
    void LateUpdate()
    {
        UpdateBlackBoard();
    }

    // Updates BlackBoard for next Frame
    void UpdateBlackBoard()
    {
        CurBBoard = NextBBoard;
    }
}

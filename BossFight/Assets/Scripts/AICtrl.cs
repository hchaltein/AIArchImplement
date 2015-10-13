using UnityEngine;
using System.Collections;

public class AICtrl : MonoBehaviour
{
    BlackBoard CurBBoard;
    BlackBoard NextBBoard;

    float BossHP = 100.0f;



    //Projectile Variables
    public GameObject projecPrefab;
    Transform projSpawnPoint;
    public float projSpeed = 20.0f;

    // Use this for initialization
    void Start ()
    {
        // Get initial information from Specialists

        // Instantiate the BBoard

        // 


        // Get Spawn point position
        projSpawnPoint = transform.FindChild("ArmCanon").transform;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootProj();
        }
	
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

    void ShootProj()
    {
        GameObject Projectile = (GameObject)Instantiate(projecPrefab, projSpawnPoint.position, Quaternion.identity);

    // Fires projectile.
    Projectile.GetComponent<Rigidbody>().velocity = transform.forward* projSpeed;
    }



}

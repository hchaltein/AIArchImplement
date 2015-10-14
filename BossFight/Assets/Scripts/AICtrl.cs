using UnityEngine;
using System.Collections;

public class AICtrl : MonoBehaviour
{

    Transform MyTransform;
    Rigidbody MyRgdBdy;

    BlackBoard CurBBoard;
    BlackBoard NextBBoard;

    bool isFacingRight;
    public bool isGrounded;
    public float MoveSpeed;
    public float JumpSpeed;
    float BossHP = 100.0f;

    //Projectile Variables
    public GameObject projecPrefab;
    Transform projSpawnPoint;
    public float projSpeed = 20.0f;

    // Use this for initialization
    void Start ()
    {
        // Component Gets
        projSpawnPoint = transform.FindChild("ArmCanon").transform;
        MyRgdBdy = GetComponent<Rigidbody>();
        MyTransform = transform;

        // Face Left
        isFacingRight = true;
        isGrounded = true;
        
        // Make boss Face Left
        MoveLeft();

        // Default Speeds
        MoveSpeed = 10.0f;
        JumpSpeed = 30.0f;

        // Get initial information from Specialists

        // Instantiate the BBoard

    }
	
	// Update is called once per frame
	void Update ()
    {
        // Input
        // Move Right
        if (Input.GetKey(KeyCode.D))
            MoveRight();

        // Move Left
        if (Input.GetKey(KeyCode.A))
            MoveLeft();

        //Jump
        if (Input.GetKey(KeyCode.W))
            Jump();

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
            ShootProj();
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
        if (isFacingRight)
        {
            Projectile.GetComponent<Rigidbody>().velocity = transform.forward * projSpeed;
        }
        else
        {
            Projectile.GetComponent<Rigidbody>().velocity = transform.forward * -projSpeed;
        }
    }

    void MoveRight()
    {
        // If facing wrong direction, flip.
        if (!isFacingRight)
        {
            MyTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            isFacingRight = true;
        }
        MyRgdBdy.velocity = new Vector3(MoveSpeed, MyRgdBdy.velocity.y);
    }

    void MoveLeft()
    {
        //If facing wrong direction, flip.
        if (isFacingRight)
        {
            MyTransform.localScale = new Vector3(1.0f, 1.0f, -1.0f);
            isFacingRight = false;
        }

        MyRgdBdy.velocity = new Vector3(-MoveSpeed, MyRgdBdy.velocity.y);
    }

    void Jump()
    {
        if (isGrounded && MyRgdBdy.velocity.y == 0)
        { // Can jump
            MyRgdBdy.velocity += new Vector3(0, JumpSpeed);
        }
    }



}

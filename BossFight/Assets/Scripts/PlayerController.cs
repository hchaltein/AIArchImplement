using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Player Stats
    float PlayerHP = 1.0f;

    // Component Variables
    Transform MyTransform;
    Rigidbody MyRgdBdy;

    public GameObject BossObj;
    BlkBrdMngr BlkBrdMngr;

    // Player Variables
    bool isFacingRight;
    public bool isGrounded;
    public float MoveSpeed;
    public float JumpSpeed;

    //Projectile Variables
    public GameObject projecPrefab;
    Transform projSpawnPoint;
    public float projSpeed = 20.0f;

    // Use this for initialization
    void Start ()
    {
        //  Component Gets
        MyRgdBdy = GetComponent<Rigidbody>();
        MyTransform = transform;
        projSpawnPoint = transform.FindChild("ArmCanon").transform;

        BlkBrdMngr = BossObj.GetComponent<BlkBrdMngr>();

        // Face Right
        isFacingRight = true;
        isGrounded = true;

        // Default Speeds
        MoveSpeed = 10.0f;
        JumpSpeed = 30.0f;
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
        if (Input.GetKeyDown(KeyCode.W) )
            Jump();

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
            ShootProj();

        // Updates the Black Board
        BlkBrdMngr.WriteBlckBrd.PlyrHP = PlayerHP;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossBullet")
        {
            PlayerHP -= 0.05f;
        }
    }


    void ShootProj()
    {
        GameObject Projectile = (GameObject)Instantiate(projecPrefab, projSpawnPoint.position, Quaternion.identity);

        // Fires projectile.
        if(isFacingRight)
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
        if (isGrounded )
        { // Can jump
            MyRgdBdy.velocity += new Vector3(0, JumpSpeed);
        }
    }
}

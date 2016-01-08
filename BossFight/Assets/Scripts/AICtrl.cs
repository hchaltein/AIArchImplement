using UnityEngine;
using System.Collections;

public class AICtrl : MonoBehaviour
{
    //Boss Stats Variables.
    float BossHP = 1.0f;

    BlkBrdMngr BlkBrdMngr;

    //Movement Variables
    Transform MyTransform;
    Rigidbody MyRgdBdy;

    bool isFacingRight;
    public bool isGrounded;
    public float MoveSpeed;
    public float JumpSpeed;

    //Projectile Variables
    public GameObject projecPrefab;
    Transform projSpawnPoint;
    public float projSpeed = 20.0f;

    // Use this for initialization
    void Start()
    {
        // Component Gets
        projSpawnPoint = transform.FindChild("ArmCanon").transform;
        MyRgdBdy = GetComponent<Rigidbody>();
        MyTransform = transform;

        // Black Board
        BlkBrdMngr = GetComponent<BlkBrdMngr>();

        // Face Left
        isFacingRight = true;
        isGrounded = true;

        MoveLeft();

        // Default Speeds
        MoveSpeed = 10.0f;
        JumpSpeed = 30.0f;
    }

    void Update()
    {
        // Updates the Black Board
        BlkBrdMngr.WriteBlckBrd.BossHP = BossHP;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            BossHP -= 0.05f;
        }
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
            MyTransform.localRotation = new Quaternion(0, 1, 0, 1);
            isFacingRight = true;
        }
        MyRgdBdy.velocity = new Vector3(MoveSpeed, MyRgdBdy.velocity.y);
    }

    void MoveLeft()
    {
        //If facing wrong direction, flip.
        if (isFacingRight)
        {
            MyTransform.localRotation = new Quaternion(0, -1, 0, 1);
            isFacingRight = false;
        }

        MyRgdBdy.velocity = new Vector3(-MoveSpeed, MyRgdBdy.velocity.y);
    }

    void Jump()
    {
        if (isGrounded)
        {   // Can jump
            MyRgdBdy.velocity += new Vector3(0, JumpSpeed);
        }
    }
}
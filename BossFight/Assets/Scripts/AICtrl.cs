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

    public bool isFacingRight;
    public bool isGrounded;
    public float MoveSpeed;
    public float JumpSpeed;

    //Projectile Variables
    public GameObject projecPrefab;
    Transform projSpawnPoint;
    public float projSpeed = 20.0f;
    
    //[SerializeField]
    //[Range(1,20)]
    float fireRate = 5;
    bool HasShot = false;

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
        // Bullet Collision:
        if (other.tag == "PlayerBullet")
            BossHP -= 0.05f;
        
        // Landing on the floor:
        else if (other.tag == "Floor")
            isGrounded = true;
    }

    public void ShootProj()
    {
        // Test for fire Rate.
        if (HasShot == false)
        {
            // Instantiate Bullet
            GameObject Projectile = (GameObject)Instantiate(projecPrefab, projSpawnPoint.position, Quaternion.identity);

            // Makes Bullet Move along forward vector
            Projectile.GetComponent<Rigidbody>().velocity = transform.forward * projSpeed;
            
            // Boss has shot.
            HasShot = true;
            StartCoroutine(WaitForFireRate());
        }
    }

    public void MoveRight()
    {
        // If facing wrong direction, flip.
        if (!isFacingRight)
            FaceRight();

        MyRgdBdy.velocity = new Vector3(MoveSpeed, MyRgdBdy.velocity.y);
    }

    public void MoveLeft()
    {
        //If facing wrong direction, flip.
        if (isFacingRight)
            FaceLeft();

        MyRgdBdy.velocity = new Vector3(-MoveSpeed, MyRgdBdy.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {   // Can jump
            MyRgdBdy.velocity += new Vector3(0, JumpSpeed);
            isGrounded = false;
        }
    }

    public void FaceLeft()
    {
        MyTransform.localRotation = new Quaternion(0, -1, 0, 1);
        isFacingRight = false;
    }

    public void FaceRight()
    {
        MyTransform.localRotation = new Quaternion(0, 1, 0, 1);
        isFacingRight = true;
    }

    // Counter of time for the FireRate.
    IEnumerator WaitForFireRate()
    {
        //Wait for 1/fireRate to enable next shot.
        yield return new WaitForSeconds(1/fireRate);
        HasShot = false;
    }
}
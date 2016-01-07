using UnityEngine;
using System.Collections;

public class PlayerProjectileBhvr : MonoBehaviour
{
    // Time to self destruct
    public float projDestroyTime = 3.0f;
    bool IsNearBoss;
    GameObject BossObj;

    // Use this for initialization
    void Start()
    {
        IsNearBoss = false;
        BossObj = GameObject.FindGameObjectWithTag("Boss");

        Debug.Log("Bullet created and boss is: " + BossObj.ToString());

        StartCoroutine(KillSelf());
    }

    // Destroy Projectile if it hits something except who instantiated it and other projectiles.

    void OnTriggerEnter(Collider other)
    {
        // Avoid Destroying Self when shot and by other projectiles:
        if (other.tag == "Player" || other.tag == "Projectile")
            return;


        // Bullet has come near boss.
        else if (other.tag == "ProjSpec" && IsNearBoss == false)
        {
            IsNearBoss = true;
            BossObj.GetComponent<PrjctlRdSpec>().TotalBulletsNear++;
            return;
        }

        // Bullet was near Boss and hit something.
        else if (IsNearBoss == true)
            BossObj.GetComponent<PrjctlRdSpec>().TotalBulletsNear--;

        Destroy(this.gameObject);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "ProjSpec")
        {
            IsNearBoss = false;
            BossObj.GetComponent<PrjctlRdSpec>().TotalBulletsNear--;
        }
    }

    // Kills itself after some time.
    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(projDestroyTime);
        Destroy(this.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class PlayerProjectileBhvr : MonoBehaviour
{
    // Time to self destruct
    public float projDestroyTime = 3.0f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(KillSelf());
    }

    // Destroy Projectile if it hits something except who instantiated it and other projectiles.

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Projectile")
        {
            return;
        }

        Destroy(this.gameObject);
    }
    // Kills itself after some time.
    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(projDestroyTime);
        Destroy(this.gameObject);
    }
}

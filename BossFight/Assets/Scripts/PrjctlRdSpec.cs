using UnityEngine;
using System.Collections;

public class PrjctlRdSpec : MonoBehaviour
{
    public bool isBulletNear;
    public int BulletsNear;

    // Use this for initialization
    void Start()
    {
        BulletsNear = 0;
        isBulletNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletsNear == 0)
            isBulletNear = false;
        else
            isBulletNear = true;
    }

}

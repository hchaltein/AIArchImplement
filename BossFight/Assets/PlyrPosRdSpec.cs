using UnityEngine;
using System.Collections;

public class PlyrPosRdSpec : MonoBehaviour
{
    AICtrl AiControler;
    Transform MyTransform;

    public Transform PlyrTransform;

    public float DistToPlayer;

    public void Awake()
    {
        AiControler = GetComponent<AICtrl>();
        MyTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        DistToPlayer = (PlyrTransform.position - MyTransform.position).magnitude;


        updateBlackBox();
    }

    void updateBlackBox()
    {
        AiControler.WriteBlckBrd.PlyrTransform = PlyrTransform;
        AiControler.WriteBlckBrd.BossTransform = MyTransform;
        AiControler.WriteBlckBrd.DistToPlayer = DistToPlayer;
    }
}

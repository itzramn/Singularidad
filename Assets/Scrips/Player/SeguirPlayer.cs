using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    public GameObject Target;
    private Vector3 TargetPos;
    public float haciaAdelante;
    public float Smoothing;
    public float Y;

    void Start()
    {
        
    }

    void Update()
    {
        TargetPos = new Vector3 (Target.transform.position.x,Target.transform.position.y, -468 );
        if (Target.transform.localScale.x == 1)
        {
            TargetPos = new Vector3(TargetPos.x + haciaAdelante, Target.transform.position.y+Y, -468);
        }
        if (Target.transform.localScale.x == -1)
        {
            TargetPos = new Vector3(TargetPos.x - haciaAdelante, Target.transform.position.y-Y, -468);
        }
        transform.position = Vector3.Lerp(transform.position, TargetPos, Smoothing* Time.deltaTime);
    }
}

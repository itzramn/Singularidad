using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMove : MonoBehaviour
{
    public GameObject PlatforMove;
    public Transform StarPoint;
    public Transform EndPoint;
    public float Velocidad;
    private Vector3 MoverHacia;


    void Start()
    {
        MoverHacia = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
       PlatforMove.transform.position = Vector3.MoveTowards(PlatforMove.transform.position, MoverHacia, Velocidad* Time.deltaTime);
       if(PlatforMove.transform.position == EndPoint.position)
       {
           MoverHacia = StarPoint.position;
       }
       if(PlatforMove.transform.position == StarPoint.position)
       {
           MoverHacia = EndPoint.position;
       }
    }
    
}

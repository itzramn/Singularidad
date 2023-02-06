using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   public float duracion =1.5f;
   public float magnitud = 1.5f;

public IEnumerator Shake()
{
    Vector3 originalPos =transform.localPosition;
    float elapsed =0f;
    while(elapsed<duracion)
    {
        float x = Random.Range(-1f,1f)* magnitud;
        float y = Random.Range(-1f,1f)* magnitud;
         transform.localPosition = new Vector3(x,y, originalPos.z);
         elapsed+= Time.deltaTime;
         yield return null;


    }
    transform.localPosition= originalPos;
}


}

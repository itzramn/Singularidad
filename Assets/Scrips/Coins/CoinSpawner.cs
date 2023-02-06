using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    float tiempo;
    public float rangoA, rangoB;
    public float rangoA_y, rangoB_y;
    public GameObject CoinPrefab;

    // Update is called once per frame
    void Update()
    {
        tiempo+= Time.deltaTime;
        if(tiempo >=2f)
        {
            tiempo=0;
            float x = Random.Range(rangoA, rangoB);
            float y = Random.Range(rangoA_y, rangoB_y);
            Quaternion rotacion = new Quaternion();
            Vector3 position = new Vector3(x,y,0);
            Instantiate(CoinPrefab, position, rotacion);
        }
        

    }
}

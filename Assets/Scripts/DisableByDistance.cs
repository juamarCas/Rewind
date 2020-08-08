using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableByDistance : MonoBehaviour
{
    public GameObject Player; 
    public GameObject Obstacle; 
    public float maxDistance; 
   
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.transform.position, Obstacle.transform.position); 
        if(dist >= maxDistance){
            Obstacle.SetActive(false); 
        }else{
            Obstacle.SetActive(true); 
        }
    }
}

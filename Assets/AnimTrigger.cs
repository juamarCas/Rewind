using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTrigger : MonoBehaviour
{
    [SerializeField]
    Platform pl; 
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player")  pl.ActivateAnimation();        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    private float param; 
    private float t = 1; 
    protected float speed = 10; 
    public Transform max; 
    public Transform min; 
    private bool playerOnTop = false; 

    protected void LimitMovement(){
        this.transform.position = new Vector2(this.transform.position.x, 
        Mathf.Clamp(this.transform.position.y, min.transform.position.y, max.transform.position.y));
    }

    public virtual void setParam(float p){
       
    }

    void OnCollisionEnter2D(Collision2D other) {

       // Debug.Log(other.otherCollider.name); 
        if(other.collider.tag == "Player"){
            Debug.Log("entered"); 
            playerOnTop = true;
        }
       
    }


    void OnCollisionExit2D (Collision2D other) {
       
        if(other.collider.tag == "Player"){
            Debug.Log("down"); 
            playerOnTop = false;
        }
        
    }

    public bool GetPlayerOnTop(){
        return playerOnTop; 
    }
}

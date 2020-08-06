using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame updat
    public float speed = 10; 
    public float powerStartingTime; 

    [SerializeField]
    protected Rigidbody2D rb; 
    protected float powerCounter; 
    protected bool powerActivated; 
    protected bool animActivated = false; 

    [SerializeField]
    protected Player player; 

    private bool playerOnTop = false; 
   
    private void Awake(){
        powerCounter = powerStartingTime; 
        rb = GetComponent<Rigidbody2D>(); 
    }
    

    public virtual void setParam(float p){
       
    }

    public virtual void SetPowerTimer(){

    }

    public virtual void ActivateAnimation(){

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

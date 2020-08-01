using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformn : Platform
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitMovement(); 
    }

    public void Hello(){
        Debug.Log("Hello"); 
    }

    public override void setParam(float p){
         transform.Translate(0, p*speed*Time.deltaTime, 0);  
         
    }
}

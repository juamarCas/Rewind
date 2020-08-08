using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Platform
{
    private bool isSelected = false; 
    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
         if (powerCounter <= 0) {
            powerActivated = false;
            isSelected = false; 
            player.nullSavedGO ();
            powerCounter = powerStartingTime;
        } else if (powerActivated) {
            powerCounter -= Time.deltaTime;
        }
        if(!isSelected)
            transform.Rotate(new Vector3(0,0,1)*-speed*Time.deltaTime);

         
    }

     public override void SetPowerTimer () {
        Debug.Log ("Setting time");
        powerCounter = powerStartingTime;
        powerActivated = true; 
        isSelected = true; 
    }

    public override void setParam (float p) {
        transform.Rotate(new Vector3(0,0,1)*-p*speed*Time.deltaTime); 
    }
}

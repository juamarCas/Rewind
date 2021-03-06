﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformn : Platform {
    // Start is called before the first frame update

    public GameObject min;
    public GameObject max; 
    void Start () {
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update () {
        LimitMovement ();
        if (powerCounter <= 0) {
            rb.isKinematic = false;
            powerActivated = false;
            player.nullSavedGO ();
            powerCounter = powerStartingTime;
        } else if (powerActivated) {
            powerCounter -= Time.deltaTime;
        }

        LimitMovement(); 
    }

    private void LimitMovement(){
        this.transform.position = new Vector2(this.transform.position.x, 
        Mathf.Clamp(this.transform.position.y, min.transform.position.y, max.transform.position.y));
    }

    public void Hello () {
        Debug.Log ("Hello");
    }

    public override void setParam (float p) {
        transform.Translate (p * speed * Time.deltaTime, 0, 0);
    }

    public override void SetPowerTimer () {
        Debug.Log("Setting time"); 
        rb.isKinematic = true;
        powerActivated = true;
        powerCounter = powerStartingTime;  
    }

    public override void ActivateAnimation () {
        if (!animActivated) {
            rb.isKinematic = false;
            animActivated = true; 
        }
    }
}
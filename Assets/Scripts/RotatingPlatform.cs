using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : Platform {
    // Start is called before the first frame update
    public Transform pivot;
    public float maxRot;
    public float minRot;
    private TargetJoint2D j;
    public bool isSelected = false;
    float prevIntertia;

    void Start () {
        j = GetComponent<TargetJoint2D> ();

        rb.isKinematic = true;
        //rb.inertia = 1000;
        prevIntertia = rb.inertia;
    }
    private void Update () {

        //LimitMovement ();
        if (powerCounter <= 0) {
            rb.isKinematic = false;
            powerActivated = false;
            player.nullSavedGO ();
            powerCounter = powerStartingTime;
        } else if (powerActivated) {
            powerCounter -= Time.deltaTime;
        }

    }

    public override void setParam (float p) {
        if (this.transform.eulerAngles.z <= 0) return;
        transform.RotateAround (pivot.position, new Vector3 (0, 0, 1), speed * p * Time.deltaTime);
    }

    public override void SetPowerTimer () {
        Debug.Log ("Setting time");
        powerCounter = powerStartingTime;
    }

    public override void ActivateAnimation () {
        if (!animActivated) {
            rb.isKinematic = false;
            animActivated = true;
        }
    }

}
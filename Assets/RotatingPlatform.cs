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
   
    void Start () {
        j = GetComponent<TargetJoint2D> ();
        j.target = pivot.transform.position;
    }
    private void Update () {
   
        LimitMovement ();

    }

    void LimitMovement () {
        if (isSelected) {
            transform.eulerAngles = new Vector3 (0.0f,
                0.0f,
                Mathf.Clamp (this.transform.eulerAngles.z, minRot, maxRot));

        }
    }
    public override void setParam (float p) {
        
        transform.RotateAround (pivot.position, new Vector3 (0, 0, 1), speed * p * Time.deltaTime);
    }

    public override void SetPowerTimer () {
        rb.isKinematic = true;
    }

}
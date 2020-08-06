using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Start is called before the first frame update
    [Header ("Components")]
    public float speed = 5;
    public int maxRayCastDist = 5;
    public GameObject weapon;
    public LayerMask whatCanBeSelected;
    public float jumpForce = 10; 

    [Header("Ground check")]
    public GameObject groundChecker; 
    public LayerMask whatIsGround; 
    public float checkRadius = 1.0f; 
    

    private Rigidbody2D rb;
    private float moveIn;
    private GameObject savedGO;
    private float dChange = 1;
    private bool isGrounded;
    private Platform pl; 

    [Header("Animator")]
    [SerializeField]
    private Animator anim; 

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        
    }

    // Update is called once per frame
    void Update () {
        
        moveIn = Input.GetAxis ("Horizontal");
        rb.velocity = new Vector2 (moveIn * speed, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(moveIn)); 
        anim.SetBool("Jump",!isGrounded); 
        if(rb.velocity.x > 0){
            this.transform.localScale = new Vector3(1,
            this.transform.localScale.y, 
            this.transform.localScale.z); 
        }else if(rb.velocity.x < 0){
            this.transform.localScale = new Vector3(-1,
            this.transform.localScale.y, 
            this.transform.localScale.z); 
        }
        Ability ();

    }

    void FixedUpdate () {
        Control ();
    }

    void Ability () {
        #region jump
        if(Physics2D.OverlapCircle(groundChecker.transform.position, checkRadius, whatIsGround) || Physics2D.OverlapCircle(groundChecker.transform.position, checkRadius, whatCanBeSelected)){
            isGrounded = true; 
        }else{
            isGrounded = false; 
        }
        if(Input.GetKeyDown(KeyCode.W) && isGrounded){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
        }
        #endregion
        
        #region selectionPower
        if (Input.GetMouseButtonDown (0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            Vector3 dir = mousePos - this.gameObject.transform.position;
            dir.z = 0;
            RaycastHit2D hit = Physics2D.Raycast (weapon.transform.position, dir, maxRayCastDist, whatCanBeSelected);
            if (hit.collider != null) {
                Debug.Log ("hitted");
                savedGO = hit.collider.gameObject;
                pl = savedGO.gameObject.GetComponent<Platform> (); 
                pl.SetPowerTimer(); 
            }
        }
        #endregion
    }

    void Control () {
        if (savedGO != null) {
            
            if (!pl.GetPlayerOnTop ()) {
                if (Input.GetKey (KeyCode.Q)) {
                    pl.setParam (-dChange);
                } 
                else {
                    pl.setParam (0);
                }
            }

        }
    }

    public void nullSavedGO(){
        pl = null; 
        savedGO = null; 
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(groundChecker.transform.position, checkRadius); 
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float forceMagnitude;

    private Rigidbody2D rb;
    private Camera mainCam;
    private Vector2 direction;
    private SpriteRenderer sr;

    private bool isTouched = false;

    private void Awake() {
        mainCam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb == null) return;

        GetPosition();

    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MovePlayer(){
        if(direction != null && direction != Vector2.zero){
            rb.velocity = direction * forceMagnitude * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Slime")) {
            Debug.Log("slime is hit");
            //rb.isKinematic = false;
            direction = Vector2.zero;
            rb.velocity = Vector3.zero;
            isTouched = false;

            sr.flipX = true;
            
            rb.freezeRotation = true;
            //transform.Rotate(0f,0f,0f, Space.Self);
            //Debug.Log(rb.velocity.ToString());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Flag")) {
            SceneManager.LoadScene(0);
        }
    }

    private void GetPosition(){
        if(Touchscreen.current.primaryTouch.press.isPressed && !isTouched){

                
            //Debug.Log("Pressed");
            //rb.isKinematic = true;
            Vector2 screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCam.ScreenToWorldPoint(screenPosition);

            worldPosition.z = 0f;
            
            direction = worldPosition - transform.position;
            direction.Normalize();

            Debug.Log(direction.ToString());

            isTouched = true;

            rb.freezeRotation = false;
            transform.Rotate(0f,0f,1f,Space.Self);


            sr.flipX = false;
 
        }
    }
}

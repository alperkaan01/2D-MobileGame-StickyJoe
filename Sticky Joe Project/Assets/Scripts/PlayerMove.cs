using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float forceMagnitude;

    private Rigidbody2D rb;
    private Camera mainCam;
    private Vector2 direction;


    private bool isTouched = false;

    private void Awake() {
        mainCam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
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
            rb.velocity = Vector2.zero;
            isTouched = false;
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
 
        }
    }
}

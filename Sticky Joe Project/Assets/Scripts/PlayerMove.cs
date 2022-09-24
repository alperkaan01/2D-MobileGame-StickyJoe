using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float forceMagnitude;
    [SerializeField] private LevelComplete levelCompletion;

    private Rigidbody2D rb;
    private Camera mainCam;
    private Vector2 direction;
    private SpriteRenderer sr;
    private bool isTouched = false;
    public static int coinCount = 0;


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

        RotatePlayer();

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

            direction = Vector2.zero;
            rb.velocity = Vector3.zero;
            isTouched = false;

            sr.flipX = true;
            
            rb.freezeRotation = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Flag")) { //If we reach to the flag we can understand that the level is completed
            levelCompletion.LevelCompleted(); // Level completion flag revealed
        }else if(other.CompareTag("Coin")){
            coinCount += 1;
            Destroy(other.gameObject);
        }
    }

    private void GetPosition(){
        if(Touchscreen.current.primaryTouch.press.isPressed && !isTouched){
            
            Vector2 screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCam.ScreenToWorldPoint(screenPosition);

            worldPosition.z = 0f;
            
            direction = worldPosition - transform.position;
            direction.Normalize();

            Debug.Log(direction.ToString());

            isTouched = true;

            rb.freezeRotation = false;
            



            sr.flipX = false;
 
        }
    }

    private void RotatePlayer(){
        if(isTouched){
            if(direction.x < 0){
                transform.Rotate(new Vector3(0f, 0f, 150f) * Time.deltaTime);
            }else {
                transform.Rotate(new Vector3(0f, 0f, -150f) * Time.deltaTime);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject UpperPivot;
    [SerializeField] private GameObject LowerPivot;
    [SerializeField] private Vector2 speedInterval;
    [SerializeField] private float speedIncrementRate;

    private Transform upperTarget;
    private Transform lowerTarget;
    private Transform mainTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = UpperPivot.transform.position;

        upperTarget = UpperPivot.transform;
        lowerTarget = LowerPivot.transform;
    }

    // Update is called once per frame
    void Update()
    {

        IncrementSpeed();
        MoveBetweenTargets();

        
    }

    void MoveBetweenTargets(){
        if(Vector2.Distance(transform.position, upperTarget.position) < 0.01f){
            mainTarget = lowerTarget;
        }else if(Vector2.Distance(transform.position, lowerTarget.position) < 0.01f){
            mainTarget = upperTarget;
        }
        

        //move between the pivot points
        transform.position = Vector2.MoveTowards(transform.position, mainTarget.position, moveSpeed * Time.deltaTime);
    }

    private void IncrementSpeed(){

        if(moveSpeed < speedInterval.y) {
            moveSpeed += Time.deltaTime * speedIncrementRate;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaterSpawnEnemy : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private GameObject mainMaze;
    [SerializeField] private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("InitEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(mainMaze.gameObject == null) {
            StopCoroutine("TrackTarget");
            StopCoroutine("InitEnemy");
            return;}
        StartCoroutine("TrackTarget");
    }

    IEnumerator InitEnemy() {
        yield return new WaitForSeconds(2f);

        mainMaze.gameObject.SetActive(true);
    }

    IEnumerator TrackTarget(){
        

        mainMaze.gameObject.transform.position = Vector2.MoveTowards(mainMaze.gameObject.transform.position, target.position, moveSpeed * Time.deltaTime);

        yield return new WaitForSeconds(10f);

        Destroy(mainMaze.gameObject);


    }
}

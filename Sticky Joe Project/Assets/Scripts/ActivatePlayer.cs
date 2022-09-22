using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {   
        player.gameObject.transform.position = transform.position;
        player.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

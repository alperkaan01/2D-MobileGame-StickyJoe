using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMace : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}

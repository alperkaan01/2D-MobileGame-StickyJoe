using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start() {
        
    }
    
    public void goToMainMenu(){
        SceneManager.LoadScene(3);
    }
}

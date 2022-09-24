using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject player;
    [SerializeField] private Image[] starArray;
    
    private void Start() {
        levelCompletePanel.gameObject.SetActive(false);
    }
    

    public void LevelCompleted(){

        levelCompletePanel.gameObject.SetActive(true);

        StarManager();
        
    }   
    
    private void StarManager(){
        
        for(int i = 0 ; i < PlayerMove.coinCount; i++ ){
            
            var tempColor = starArray[i].GetComponent<Image>().color;

            tempColor.a = 1f;

            starArray[i].GetComponent<Image>().color = tempColor;

        }
    }

    public void ReplayButton(){
        SceneManager.LoadScene(3);
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene(0); //Change this with main menu at the end, instead of intro scene
    }

    public void NextLevel(){
        SceneManager.LoadScene(4);
    }
}

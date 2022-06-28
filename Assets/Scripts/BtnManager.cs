using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject mainPanel;

    public GameObject overLay1;
    public GameObject overLay2;
    public GameObject overLay3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame(){
        SceneManager.LoadScene("Level1");
    }
     public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void LevelMenu(){
        Application.Quit();
    }
    public void SoundBtn(){
        Application.Quit();
    }
    public void InfoBtn(){
        mainPanel.SetActive(false); 
        infoPanel.SetActive(true);
        overLay1.SetActive(true);
    }

    public void firstPageClick(){
        overLay1.SetActive(false);
        overLay2.SetActive(true);
        overLay3.SetActive(false);
    }
    public void SeconndPageClick(){
        overLay1.SetActive(false);
        overLay2.SetActive(false);
        overLay3.SetActive(true);
    }
    public void thirdPageClick(){
        overLay3.SetActive(false);
        infoPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

}

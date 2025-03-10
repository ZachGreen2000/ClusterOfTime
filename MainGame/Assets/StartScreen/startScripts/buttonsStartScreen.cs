using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsStartScreen : MonoBehaviour
{
    public startManager mapScript;
    public GameObject startButton;
    public GameObject pirateButton;
    public GameObject medievilButton;
    public GameObject greeceButton;
    public GameObject egyptButton;
    public GameObject popUpText;
    public GameObject settingsScreen;
    public GameObject backButton;
    public GameObject settingsBackButton;
    public string HomeScene;

    public void activateButtons()
    {
        Debug.Log("buttons activated");
        pirateButton.SetActive(true);
        medievilButton.SetActive(true);
        greeceButton.SetActive(true);
        egyptButton.SetActive(true);
        popUpText.SetActive(true);
        backButton.SetActive(true);
    }

    public void mapButtonClick()
    {
        Debug.Log("ckicked");
        SceneManager.LoadScene(HomeScene);
    }

    public void backClick()
    {
        mapScript.resetAnimation();
        pirateButton.SetActive(false);
        medievilButton.SetActive(false);
        greeceButton.SetActive(false);
        egyptButton.SetActive(false);
        popUpText.SetActive(false);
        backButton.SetActive(false);
    }

    public void startClick() {
        mapScript.Animation();
    }

    public void settingsClick()
    {
        settingsScreen.SetActive(true);
    }

    public void settingsBackClick()
    {
        settingsScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        pirateButton.SetActive(false);
        medievilButton.SetActive(false);
        greeceButton.SetActive(false);
        egyptButton.SetActive(false);
        popUpText.SetActive(false);
        settingsScreen.SetActive(false);
        backButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

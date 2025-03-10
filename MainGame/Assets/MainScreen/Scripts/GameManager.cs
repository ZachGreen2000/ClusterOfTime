using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int timer = 0;
    public bool monday = false;
    public bool tuesday = false;
    public bool wednesday = false;
    public bool thursday = false;
    public bool friday = false;
    public bool saturday = false;
    public bool sunday = false;
    public Camera playerHomeCam;
    public Camera homeHomeCam;
    public Camera npcCam;

    void dayOfTheWeek()
    {
        if (timer == 0)
        {
            monday = true;
            Debug.Log("Monday");
        }else if (timer==400)
        {
            monday=false;
            tuesday = true;
            Debug.Log("Tuesday");
        }else if (timer==600)
        {
            tuesday=false;
            wednesday=true;
            Debug.Log("Wednesday");
        }else if (timer==800)
        {
            wednesday = false;
            thursday=true;
            Debug.Log("Thursday");
        }else if (timer==1000)
        {
            thursday = false;
            friday=true;
            Debug.Log("Friday");
        }else if(timer==1200)
        {
            friday = false;
            saturday=true;
            Debug.Log("Saturday");
        }else if (timer ==1400)
        {
            saturday = false;
            sunday=true;
            Debug.Log("Sunday");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        playerHomeCam.gameObject.SetActive(false);
        homeHomeCam.gameObject.SetActive(false);
        npcCam.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        dayOfTheWeek();
        if (timer >= 0)//a day is 24mins == timer 86400
        {
            timer++;
        }else if (timer == 1500)
        {
            timer = 0;
        }
        
    }
}

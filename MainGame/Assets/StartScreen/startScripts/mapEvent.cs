using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapEvent : MonoBehaviour
{
    public buttonsStartScreen buttonScript;
    public void onAnimationEvent()
    {
        buttonScript.activateButtons();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

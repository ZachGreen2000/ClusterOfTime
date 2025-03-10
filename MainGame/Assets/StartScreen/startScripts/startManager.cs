using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startManager : MonoBehaviour
{
    public GameObject map;
    public Animator animator;

    public void Animation()
    {
        map.gameObject.SetActive(true);
        animator.SetBool("checked", true);
        animator.SetBool("unchecked", false);
    }

    public void resetAnimation()
    {
        map.gameObject.SetActive(false);
        animator.SetBool("unchecked", true);
        animator.SetBool("checked", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        map.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 20;
    public int health = 20;
    public int minHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void damage(int dmg)
    {
        if (health <= maxHealth) 
        {
            health = health - dmg;
        }
    }

    public void playerDeath()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (health < minHealth)
        {
            playerDeath();
        }
    }
}

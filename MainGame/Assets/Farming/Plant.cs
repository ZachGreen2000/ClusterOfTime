using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Plant : MonoBehaviour
{
    public int day_planted;

    public Plant_Details details;
    public Plant_Manager manager;
    public int pot_number;

    private bool grown = false;
    public bool get_grown()
    {
        return grown;
    }

    public void Initialize_Plant(int plant_number)
    {
        gameObject.name = details.name;

        Plant_Pot pot = manager.plant_pots[pot_number];
        pot.Set_Plant(this);

        update_sprite();
    }

    public void update_sprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        int days_planted = manager.Current_Date - day_planted;
        float percent_planted = (float)days_planted / (float)details.growth_time;
        if (percent_planted >= 1)
        {
            spriteRenderer.sprite = details.final_sprite;
            spriteRenderer.sortingOrder = 1;
            grown = true;
        }
        else
        {
            if (percent_planted > 0)
            {             
                spriteRenderer.sprite = details.growth_stages[0];
                grown = false;
            }
            int growth_index = Mathf.FloorToInt(percent_planted * details.growth_stages.Length);
            spriteRenderer.sprite = details.growth_stages[growth_index];
            grown = false;
        }
    }

    public void harvest()
    {
        Debug.Log("Harvest Plant");
        manager.mark_save_dirty();
        // TODO Play Harvest Sound
        // TODO Add To Inventory
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Plant_Pot : MonoBehaviour
{
    public Plant Plant;

    public void Set_Plant(Plant plant)
    {
        Plant = plant;
        gameObject.name = "Plant Pot " + plant.pot_number + " - " + plant.details.name;
    }
}

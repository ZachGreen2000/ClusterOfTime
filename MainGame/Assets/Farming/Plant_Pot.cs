using UnityEngine;

public class Plant_Pot : MonoBehaviour
{
    public Plant Plant;
    public float Plant_Offset;

    public void Set_Plant(Plant plant)
    {
        Plant = plant;
        gameObject.name = "Plant Pot " + plant.pot_number + " - " + plant.details.name;

        plant.transform.localPosition = new Vector3(0, Plant_Offset, 0);
    }
}

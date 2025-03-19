using UnityEngine;

public class Plant_Pot : MonoBehaviour
{
    public Plant Plant;
    public float Plant_Offset;

    public void Set_Plant(Plant plant)
    {
        Plant = plant;
        gameObject.name = "Plant Pot " + plant.pot_number + " - " + plant.details.name;

        Transform plant_transform = plant.transform;

        plant_transform.parent = this.transform;

        plant_transform.localScale = Vector3.one;
        plant_transform.localPosition = new Vector3(0, Plant_Offset, 0);
    }
}

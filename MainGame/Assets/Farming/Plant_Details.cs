using UnityEngine;

[CreateAssetMenu(fileName = "Plant_Details", menuName = "Scriptable Objects/Plant_Details")]
public class Plant_Details : ScriptableObject
{
    public new string name;
    public string description;

    public int growth_time;

    public Sprite[] growth_stages;
    public Sprite final_sprite;
}

using System;
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Plant_Manager : MonoBehaviour
{
    public Plant[] plants;
    public Plant_Pot[] plant_pots;
    public int Current_Date;

    [SerializeField] Plant_Details default_plant;
    private bool save_dirty = false;

    private const string path = "/plants.json";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Load_Plants();
        Debug.Log(Application.persistentDataPath + path);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Saving Plants...");
            Save_Plants();
            Debug.Log("Plants Saved");
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Loading Plants...");
            Load_Plants();
            Debug.Log("Plants Loaded");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Current_Date += 1;
            foreach (Plant plant in plants)
            {
                plant.update_sprite();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            Current_Date -= 1;
            foreach (Plant plant in plants)
            {
                plant.update_sprite();
            }
        }
    }

    void LateUpdate()
    {
        if (save_dirty)
        {
            Save_Plants();
            save_dirty = false;
        }
    }

    public void mark_save_dirty()
    {
        save_dirty = true;
    }

    public void Save_Plants()
    {
        update_array();

        Plant_Save_Details Save_Details = new Plant_Save_Details(plants);
        string Json_Save = JsonUtility.ToJson(Save_Details, true);

        string file_path = Application.persistentDataPath + path;
        File.WriteAllText(file_path, Json_Save);
    }

    private void update_array()
    {
        // Calculate New Array Size
        int new_size = 0;
        foreach (Plant plant in plants){
            if (plant != null) {
                new_size++;
            }
        }
        Plant[] new_plant = new Plant[new_size];
        int i = 0;
        foreach (Plant plant in plants)
        {
            if (plant != null) {
                new_plant[i] = plant;
                i++;
            }
        }
        plants = new_plant;
    }

    private void Load_Plants()
    {
        string file_path = Application.persistentDataPath + path;

        if (System.IO.File.Exists(file_path))
        {
            string json_data = File.ReadAllText(file_path);

            Plant_Save_Details Save_Details = JsonUtility.FromJson<Plant_Save_Details>(json_data);

            plants = new Plant[Save_Details.date_planted.Length];
            for (int i = 0; i < Save_Details.date_planted.Length; i++)
            {
                GameObject new_plant_object = new GameObject();
                new_plant_object.AddComponent<SpriteRenderer>();
                Plant new_plant = new_plant_object.AddComponent<Plant>();

                new_plant.day_planted = Save_Details.date_planted[i];
                new_plant.details = Save_Details.plant_Details[i];
                new_plant.pot_number = Save_Details.pot_numbers[i];
                new_plant.manager = this;

                new_plant.Initialize_Plant(i);

                plants[i] = new_plant;
            }
        } 
        else 
        {
            Debug.Log("No Plant File");

            // No Plants File
            GameObject new_plant_object = new GameObject();

            new_plant_object.AddComponent<SpriteRenderer>();
            Plant new_plant = new_plant_object.AddComponent<Plant>();

            new_plant.details = default_plant;
            new_plant.day_planted = -default_plant.growth_time;
            new_plant.manager = this;

            new_plant.Initialize_Plant(0);

            plants = new Plant[1];
            plants[0] = new_plant;

            // Save Details
            Save_Plants();
        }
    }
}

public class Plant_Save_Details
{
    public int[] date_planted;
    public Plant_Details[] plant_Details;
    public int[] pot_numbers;

    public Plant_Save_Details(Plant[] plant_array)
    {
        int plant_count = plant_array.Length;

        date_planted = new int[plant_count];
        plant_Details = new Plant_Details[plant_count];
        pot_numbers = new int[plant_count];

        for (int i = 0; i < plant_count; i++) {
            date_planted[i] = plant_array[i].day_planted;
            plant_Details[i] = plant_array[i].details;
            pot_numbers[i] = plant_array[i].pot_number;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RC_CityBuilder : MonoBehaviour
{

    [Header("GeneralStuff")]
    [Range(0, 1)] public float SpecialBldFloorChance;
    [Range(0, 1)] public float LargeBldFloorChance;
    [Range(0, 1)] public float MediumBldFloorChance;
    [Range(0, 1)] public float SmallBldFloorChance;
    [Range(0, 1)] public float CarChance;
    public GameObject BuildingContainer;

    [Header("SpawnpointArrays")]
    public GameObject[] SmallBuild; // 1x1
    public GameObject[] MediumBuild; // 1.5x1.5
    public GameObject[] LongBuild; // 2x1
    public GameObject[] LargeBuild; // 2x2
    public GameObject[] SpecialBuild; // Customsize
    public GameObject[] Trees;
    public GameObject[] Cars;
    public GameObject[] Trucks;

    [Header("BuildingPrefabs")]
    public GameObject[] BldPrefabs;
            /* 5 = LongBld; // 2x1
               4 = TinyBld; // 0.5x0.5
               3 = SmallBld; // 1x1
               2 = MediumBld; // 1.5x1.5
               1 = LargeBld; // 2x2
               0 = SpecialBld; // Customsize */
    public GameObject Tree;
    public GameObject[] TruckMods;
    public GameObject[] CarMods;

    [Header("BuildingGenerationStuff")]
    //public Color32 BldColor;
    public int BldHeightMax;
    public int SpecialBuildingHeightMax;
    private int BldHeight;
    public float SpawnPosIncrease;
    float offset; // for the color stuff


    // Start is called before the first frame update
    void Start()
    {
        RunGenerator();
    }

    void RunGenerator(){


        //Generate the trees
        for (int i = 0; i < Trees.Length; i++)
        {
            GameObject clone = Instantiate (Tree, Trees[i].transform.position, Quaternion.Euler (new Vector3 (0, Random.Range(0,360), 0)));
            clone.transform.parent = BuildingContainer.transform;
            clone.transform.localScale = new Vector3 (Random.Range (0.5f, 0.75f),Random.Range (0.5f, 0.75f), Random.Range (0.5f, 0.75f));
        }

        //Generate the Vehicles
        for (int i = 0; i < Cars.Length; i++)
        {
            float tempNum = Random.Range (0f,1f);
            if (tempNum >= CarChance){
                GameObject clone = Instantiate (CarMods[Random.Range(0, CarMods.Length)], Cars[i].transform); // Instatiates the car
                clone.transform.parent = BuildingContainer.transform; //Moves base into its own container

                } 
        }

        for (int i = 0; i < Trucks.Length; i++)
        {
            float tempNum = Random.Range (0f,1f);
            if (tempNum >= CarChance){
                GameObject clone = Instantiate (TruckMods[Random.Range(0, TruckMods.Length)], Trucks[i].transform); // Instatiates the car
                clone.transform.parent = BuildingContainer.transform; //Moves base into its own container

                } 
        }

        //Generate the small buildings
        for (int i = 0; i < SmallBuild.Length; i++)
        {

            int BldSize = 3; // Sets the building prefab in the array
            RandomizeColor(); // Randomises the color of the building
            Transform spawnposition = SmallBuild[i].transform; // Sets the spawn position so we can move it later.
            GameObject clone = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the base
            clone.transform.parent = BuildingContainer.transform; //Moves base into its own container
            GameObject tempGO = clone.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
            tempGO.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
            BldHeight = Random.Range (1, BldHeightMax); // Decides how big the building is going to be.
            spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor


            for (int h = 0; h < BldHeight; h++)
            {
                //move up the building size array until we get to Tiny
                float tempNum = Random.Range (0f,1f);
                if (tempNum >= SmallBldFloorChance){
                    if (BldSize != 4) {
                        BldSize++;
                    }
                } 

                GameObject floor = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the floor
                floor.transform.parent = clone.transform; //Moves the floow into its base container
                GameObject tempFloor = floor.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
                tempFloor.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
                spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor
            }


        }

        //Generate the medium buildings
        for (int i = 0; i < MediumBuild.Length; i++)
        {

            int BldSize = 2; // Sets the building prefab in the array
            RandomizeColor(); // Randomises the color of the building
            Transform spawnposition = MediumBuild[i].transform; // Sets the spawn position so we can move it later.
            GameObject clone = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the base
            clone.transform.parent = BuildingContainer.transform; //Moves base into its own container
            GameObject tempGO = clone.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
            tempGO.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
            BldHeight = Random.Range (1, BldHeightMax); // Decides how big the building is going to be.
            spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor


            for (int h = 0; h < BldHeight; h++)
            {
                //move up the building size array until we get to Tiny
                float tempNum = Random.Range (0f,1f);
                if (tempNum >= MediumBldFloorChance){
                    if (BldSize != 4) {
                        BldSize++;
                    }
                } 

                GameObject floor = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the floor
                floor.transform.parent = clone.transform; //Moves the floow into its base container
                GameObject tempFloor = floor.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
                tempFloor.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
                spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor
            }
        }

        //Generate the large buildings
        for (int i = 0; i < LargeBuild.Length; i++)
        {

            int BldSize = 1; // Sets the building prefab in the array
            RandomizeColor(); // Randomises the color of the building
            Transform spawnposition = LargeBuild[i].transform; // Sets the spawn position so we can move it later.
            GameObject clone = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the base
            clone.transform.parent = BuildingContainer.transform; //Moves base into its own container
            GameObject tempGO = clone.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
            tempGO.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
            BldHeight = Random.Range (1, BldHeightMax); // Decides how big the building is going to be.
            spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor


            for (int h = 0; h < BldHeight; h++)
            {
                //move up the building size array until we get to Tiny
                float tempNum = Random.Range (0f,1f);
                if (tempNum >= LargeBldFloorChance){
                    if (BldSize != 4) {
                        BldSize++;
                    }
                } 

                GameObject floor = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the floor
                floor.transform.parent = clone.transform; //Moves the floow into its base container
                GameObject tempFloor = floor.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
                tempFloor.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
                spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor
            }

        }

        //Generate the long buildings
        for (int i = 0; i < LongBuild.Length; i++)
        {
            int BldSize = 5; // Sets the building prefab in the array
            RandomizeColor(); // Randomises the color of the building
            Transform spawnposition = LongBuild[i].transform; // Sets the spawn position so we can move it later.
            GameObject clone = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the base
            clone.transform.parent = BuildingContainer.transform; //Moves base into its own container
            GameObject tempGO = clone.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
            tempGO.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
            BldHeight = Random.Range (1, BldHeightMax); // Decides how big the building is going to be.
            spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor


            for (int h = 0; h < BldHeight; h++)
            {
                GameObject floor = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the floor
                floor.transform.parent = clone.transform; //Moves the floow into its base container
                GameObject tempFloor = floor.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
                tempFloor.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
                spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor
            }


        }

        //Generate Special buidlings
        for (int i = 0; i < SpecialBuild.Length; i++)
        {

            int BldSize = 0; // Sets the building prefab in the array
            RandomizeColor(); // Randomises the color of the building
            Transform spawnposition = SpecialBuild[i].transform; // Sets the spawn position so we can move it later.
            GameObject clone = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the base
            clone.transform.parent = BuildingContainer.transform; //Moves base into its own container
            GameObject tempGO = clone.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
            tempGO.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
            BldHeight = Random.Range (8, SpecialBuildingHeightMax); // Decides how big the building is going to be.
            spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor


            for (int h = 0; h < BldHeight; h++)
            {
                //move up the building size array until we get to Tiny
                float tempNum = Random.Range (0f,1f);
                if (tempNum >= SpecialBldFloorChance){
                    if (BldSize != 4) {
                        BldSize++;
                    }
                } 

                GameObject floor = Instantiate (BldPrefabs[BldSize], spawnposition); // Instatiates the floor
                floor.transform.parent = clone.transform; //Moves the floow into its base container
                GameObject tempFloor = floor.gameObject.transform.GetChild(0).gameObject; // Grabs the model object
                tempFloor.GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(offset, 0)); // Changes the color
                spawnposition.position = new Vector3 (spawnposition.position.x, spawnposition.position.y + SpawnPosIncrease, spawnposition.position.z); // Move spawnpoint to next floor
            }

        }


    }


    void RandomizeColor()
    {
        offset = Random.Range (0, 1f);

        /* Old Method
        BldColor = new Color32(
            ( byte )Random.Range( 0, 255 ),        // R
            ( byte )Random.Range( 0, 255 ),        // G
            ( byte )Random.Range( 0, 255 ),        // B
            ( byte )Random.Range( 0, 255 ) );      // A
            */
    }

    private void Update() {
        if (Keyboard.current.rKey.wasPressedThisFrame){
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);    
        }
    }


 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_CityBuilder : MonoBehaviour
{

    [Header("GeneralStuff")]
    [Range(0, 1)] public float BldFloorChance;
    public GameObject BuildingContainer;

    [Header("SpawnpointArrays")]
    public GameObject[] SmallBuild; // 1x1
    public GameObject[] MediumBuild; // 1.5x1.5
    public GameObject[] LongBuild; // 2x1
    public GameObject[] LargeBuild; // 2x2
    public GameObject[] SpecialBuild; // Customsize

    [Header("BuildingPrefabs")]
    public GameObject TinyBld; // 0.5x0.5
    public GameObject SmallBld; // 1x1
    public GameObject MediumBld; // 1.5x1.5
    public GameObject LongBld; // 2x1
    public GameObject LargeBld; // 2x2
    public GameObject SpecialBld; // Customsize

    // Start is called before the first frame update
    void Start()
    {
        RunGenerator();
    }

    void RunGenerator(){

        GenerateSmall();
        GenerateMedium();
        GenerateLarge();
        GenerateLong();
        GenerateSpecial();
    }

    void GenerateSmall(){

        for (int i = 0; i < SmallBuild.Length; i++)
        {
            GameObject clone = Instantiate (SmallBld, SmallBuild[i].transform);
            clone.transform.parent = BuildingContainer.transform;
            clone.GetComponent<RC_BuildingGenerator>().spawnOrigin = this.gameObject;
        }
    }

    void GenerateMedium(){

        for (int i = 0; i < MediumBuild.Length; i++)
        {
            GameObject clone = Instantiate (MediumBld, MediumBuild[i].transform);
            clone.transform.parent = BuildingContainer.transform;
            clone.GetComponent<RC_BuildingGenerator>().spawnOrigin = this.gameObject;
        }
    }  

    void GenerateLarge(){

        for (int i = 0; i < LargeBuild.Length; i++)
        {
            GameObject clone = Instantiate (LargeBld, LargeBuild[i].transform);
            clone.transform.parent = BuildingContainer.transform;
            clone.GetComponent<RC_BuildingGenerator>().spawnOrigin = this.gameObject;
        }
    }

    void GenerateLong(){

        for (int i = 0; i < LongBuild.Length; i++)
        {
            GameObject clone = Instantiate (LongBld, LongBuild[i].transform);
            clone.transform.parent = BuildingContainer.transform;
            clone.GetComponent<RC_BuildingGenerator>().spawnOrigin = this.gameObject;
        }
    }

    void GenerateSpecial(){

        for (int i = 0; i < SpecialBuild.Length; i++)
        {
            GameObject clone = Instantiate (SpecialBld, SpecialBuild[i].transform);
            clone.transform.parent = BuildingContainer.transform;
            clone.GetComponent<RC_BuildingGenerator>().spawnOrigin = this.gameObject;
        }
    }
 
}

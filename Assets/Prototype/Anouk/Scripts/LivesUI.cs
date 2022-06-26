using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LivesUI : MonoBehaviour
{
    public GameObject[] hearts;
    
    // Start is called before the first frame update
    void Start()
    {
        AD_EventManager.LifeLost += RemoveLife;
    }

    private void RemoveLife()
    {
        hearts.Last().SetActive(false);
    }
}

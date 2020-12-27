using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI;
    int Ecount;
    // Start is called before the first frame update
    void Start()
    {
        inventoryUI.SetActive(false);
        Ecount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Inventory"))
        {
            Ecount++;
            if (Ecount %2 == 0)
            {
                inventoryUI.SetActive(false);
                
            }
            else
            {
                inventoryUI.SetActive(true);
            }
        }
        
        

        
        
    }
}

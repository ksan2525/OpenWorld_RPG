using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject settei;
    // Start is called before the first frame update
    void Start()
    {
        settei.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Setting();
    }

    void Setting()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            settei.SetActive(true);
        }

        
        
    }
    public bool mouse = false;

    public void ToggleValueChanged(Toggle change)
    {
        Debug.Log(change.isOn);
        if (change.isOn == true)
        {
            mouse = false;
        }
        else
        {
            mouse = true;
        }
    }



    public void OnClickCloseButton()
    {
        settei.SetActive(false);
    }
}

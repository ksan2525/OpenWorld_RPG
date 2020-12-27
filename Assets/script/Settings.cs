using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    int setteicount;
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

        if (Input.GetKeyDown(KeyCode.Escape)||Input.GetButtonDown("esc"))
        {
            setteicount++;
            if(setteicount %2 == 0)
            {
                OnClickCloseButton();
            }
            else
            {
                
                settei.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            
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
        Time.timeScale =1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

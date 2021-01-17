using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backstart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(startback);
    }

    void startback()
    {
        SceneManager.LoadScene("Start");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(endgame);
    }

    void endgame()
    {
        Application.Quit();
        Debug.Log ("おわり");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

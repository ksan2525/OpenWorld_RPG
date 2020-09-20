using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterText : MonoBehaviour
{
    GameObject player;
    Parameter parameter;
    [SerializeField] Text lvtext;
    public int lv;
    public int xp;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        parameter = player.GetComponent<Parameter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        xp = player.GetComponent<Parameter>().xp;
        lv = player.GetComponent<Parameter>().lv;
        lvtext.text = "LV=" + lv;
    }
}

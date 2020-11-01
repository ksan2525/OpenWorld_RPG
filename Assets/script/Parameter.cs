using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameter : MonoBehaviour
{
    public int lv;//現在のレベル
    public int xp;//経験値の総量
    public int hp;
    private float timeleft;
    public Text parametertext;
    // Start is called before the first frame update
    void Start()
    {
        
        xp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lv = GetLv();
        Debug.Log("lv" + GetLv());
        Text();
    }

    void HP()
    {
        
        
        
    }
    void MP()
    {

    }   
    int GetLv()
    {

        return(int) Mathf.Sqrt(xp / 10);
    }

    void Text()
    {
        parametertext.text = "LV=" + lv;
    }
    
}

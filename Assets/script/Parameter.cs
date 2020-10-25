using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter : MonoBehaviour
{
    public int lv;//現在のレベル
    public int xp;//経験値の総量
    public int hp;
    private float timeleft;
    // Start is called before the first frame update
    void Start()
    {
        
        xp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("lv" + GetLv());
       
    }

    void HP()
    {
        
        
        
    }
    void MP()
    {

    }   
    int GetLv()
    {
        return (xp / 10)*(xp/10);        
    }
    
}

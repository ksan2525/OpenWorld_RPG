using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter : MonoBehaviour
{
    public int lv;
    public int xp;
    public int hp;
    private float timeleft;
    // Start is called before the first frame update
    void Start()
    {
        lv = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        LV();
    }

    void HP()
    {
        
        if (lv == 1)
        {
            hp = 100;
        }
        if (lv == 2)
        {
            hp = 110;
        }
        
    }
    void MP()
    {

    }   
    void LV()
    {
        if (xp == 10)
        {
            lv = 2;
        }
    }
    void XP()
    {
        if(timeleft <= 0.0)
        {
            timeleft = 1.0f;
            xp + 1;
        }
    }
}

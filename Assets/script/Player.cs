using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    private Rigidbody PlayerRigid;
    public float Upspeed;
    public GameObject mainCamera;
    public Transform YAxis;
    public Transform XAxis;
    public float Speed;
    public BoxCollider attack;
    private bool isground;

    public float XSpeed = 1.0f;
    public float YSpeed = 1.0f;
    public Settings settings;
    int mousecount;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigid = player.GetComponent<Rigidbody>();
        mousecount = 0;
        
    }

    // Update is called once per frame
    float sight_z = 0;
    float sight_y = 0;
    void Update()
    {
        transform.position = player.transform.position;
        Move();
        Camera_control();        
        Attack();
        
        if(settings.mouse == true)
        {
            Camera_mouse();
        }
        else
        {
            Camera_joystick();
        }
    }


    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isground = true;
        }
    }
    void Move()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        float jx = Input.GetAxis("joystickL_Horizontal");
        float jz = Input.GetAxis("joystickL_Vertical");
        transform.Translate(dx * Speed * Time.deltaTime, 0.0f, dz * Speed * Time.deltaTime);
        transform.Translate(jx * Speed * Time.deltaTime, 0.0f, jz * Speed * Time.deltaTime);
        if (isground &&( Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Jump")))
        {
            PlayerRigid.AddForce(transform.up * Upspeed);
            isground = false;
        }
        
    }

    void Camera_mouse()
    {
        float xRotation = Input.GetAxis("Mouse X") * XSpeed;
        float yRotation = Input.GetAxis("Mouse Y") * YSpeed;
        YAxis.transform.Rotate(0, xRotation, 0);
        XAxis.transform.Rotate(-yRotation, 0, 0);
    }
    void Camera_control()
    {
        //float xRotation = Input.GetAxis("Mouse X") * XSpeed;
        //float yRotation = Input.GetAxis("Mouse Y") * YSpeed;
        //YAxis.transform.Rotate(0, xRotation, 0);
        //XAxis.transform.Rotate(-yRotation, 0, 0);//設定していないからうまくいっていない？コントローラーとおんなじ感じにしたら行けんじゃね？簡単に言えば

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(mousecount %2 == 0)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        

        if (Input.GetKeyUp(KeyCode.N))
        {
            Time.timeScale = 0.1f;
            Debug.Log("計算速度は1/10だよ");
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            Time.timeScale = 1f;
            Debug.Log("計算速度は1/1だよ");
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            Time.timeScale = 10f;
            Debug.Log("計算速度は10/1だよ");
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            attack.enabled = false;
        }
        
    }
    void Camera_joystick()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float angleH = Input.GetAxis("Horizontal2") * 5.0f;
        float angleV = Input.GetAxis("Vertical2") * 5.0f;

        
        //YAxis.transform.Rotate(0, angleH, 0);
        //XAxis.transform.Rotate(-angleV, 0, 0);
        
        if (sight_y > 80)
        {
            if(angleV < 0)
            {
                sight_y = sight_y + angleV;
            }
        }
        else if(sight_y < -90)
        {
            if(angleV > 0)
            {
                sight_y = sight_y + angleV;
            }
        }
        else
        {
            sight_y = sight_y + angleV;
        }

        if(sight_z >= 360)
        {
            sight_z = sight_z - 360;
        }
        else if(sight_z < 0)
        {
            sight_z = 360 - sight_z;
        }
        sight_z = sight_z + angleH;

        float dx = Mathf.Sin(sight_z * Mathf.Deg2Rad) * z + Mathf.Sin((sight_z + 90f) * Mathf.Deg2Rad) * x;

        float dz = Mathf.Cos(sight_z * Mathf.Deg2Rad) * z + Mathf.Cos((sight_z + 90f) * Mathf.Deg2Rad) * x;

        //transform.Translate(dx, 0, dz,0.0f);

        //↓xaxisはカメラのトランスフォームの値を動かしている、
        XAxis.transform.localRotation = Quaternion.Euler(sight_y, 0, 0);
        YAxis.transform.localRotation = Quaternion.Euler(0, sight_z, 0);
        sight_z = sight_z + angleH;

        Debug.Log("dx:dz \n" + dx + " : " + dz);

        XAxis.transform.Rotate(0, dx, 0);
        YAxis.transform.Rotate(dz, 0, 0);
    }
}

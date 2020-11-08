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
    

    public float XSpeed = 1.0f;
    public float YSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerRigid = player.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    //float sight_x = 0;
    //float sight_y = 0;
    void Update()
    {
        transform.position = player.transform.position;
        Move();
        Camera_control();
        Camera_joystick();
        Attack();
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground" && Input.GetKey(KeyCode.Space))
        {
            PlayerRigid.AddForce(transform.up * Upspeed);
        }
    }
    void Move()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        transform.Translate(dx * Speed * Time.deltaTime, 0.0f, dz * Speed * Time.deltaTime);
        
        
    }

    void Camera_control()
    {
        float xRotation = Input.GetAxis("Mouse X") * XSpeed;
        float yRotation = Input.GetAxis("Mouse Y") * YSpeed;
        YAxis.transform.Rotate(0, xRotation, 0);
        XAxis.transform.Rotate(-yRotation, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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
    //    float angleH = Input.GetAxis("joystick X") * 5.0f;
    //    float angleV = Input.GetAxis("joystick Y") * 5.0f;
    //    YAxis.transform.Rotate(0, angleH, 0);
    //    XAxis.transform.Rotate(-angleV, 0, 0);
        
        //if (sight_y > 80)
        //{
        //    if(angleV < 0)
        //    {
        //        sight_y = sight_y + angleV;
        //    }
        //}
        //else if(sight_y < -90)
        //{
        //    if(angleV > 0)
        //    {
        //        sight_y = sight_y + angleV;
        //    }
        //}
        //else
        //{
        //    sight_y = sight_y + angleV;
        //}

        //if(sight_x >= 360)
        //{
        //    sight_x = sight_x - 360;
        //}
        //else if(sight_x < 0)
        //{
        //    sight_x = 360 - sight_x;
        //}
        //sight_x = sight_x + angleH;
        //transform.localRotation = Quaternion.Euler(sight_y, sight_x, 0);


    }
}

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
    float sight_x = 0;
    float sight_y = 0;
    void Update()
    {
        transform.position = player.transform.position;
        Move();
        Camera_control();
        Camera_joystick();
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground" && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRigid.AddForce(transform.up * Upspeed);
        }
    }
    void Move()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        transform.Translate(dx * Speed, 0.0f, dz * Speed);
        
        
    }

    void Camera_control()
    {
        float xRotation = Input.GetAxis("Mouse X") * XSpeed;
        float yRotation = Input.GetAxis("Mouse Y") * YSpeed;
        YAxis.transform.Rotate(0, xRotation, 0);
        XAxis.transform.Rotate(-yRotation, 0, 0);
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

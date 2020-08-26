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
    void Update()
    {
        transform.position = player.transform.position;
        Move();
        Camera_control();
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
}

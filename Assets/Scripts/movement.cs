using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class movement : MonoBehaviour
{

    //移动的速度
    public float speed;
    //鼠标的水平偏移量
    float offsetMouseX;
    //鼠标在竖直方向上的偏移量
    float offsetMouseY;
    //人称控制器在水平方向上的旋转角度
    public float rotateX;
    private CharacterController m_CharacterController;
    private float horizontal;
    private float vertical;
    private Camera m_mianCamera;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_mianCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //控制第一人称控制器的移动效方向
        Vector3 direction = (transform.forward * vertical + horizontal * transform.right).normalized;
        m_CharacterController.SimpleMove(direction * speed * Time.deltaTime);
        //第一人称控制器左右旋转
        offsetMouseX = Input.GetAxis("Mouse X");
        m_CharacterController.transform.Rotate(Vector3.up * offsetMouseX * rotateX * Time.deltaTime);
        //第一人称控制器抬头低头看
        offsetMouseY = Input.GetAxis("Mouse Y");
        Vector3 cameraRotateAngle = -offsetMouseY * Vector3.right;
        m_mianCamera.transform.eulerAngles += cameraRotateAngle;     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public Joystick joystick;
    public float speed = 3f;
    public float size = 1f;

    CameraController mainCam;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontal = joystick.Horizontal + Input.GetAxisRaw("Horizontal");
        float vertical = joystick.Vertical + Input.GetAxisRaw("Vertical");

        rb.AddForce(Vector3.forward * vertical * speed );
        rb.AddForce(Vector3.right * horizontal * speed );
       // UnlockPickupCategory();
    }

    //碰撞检测
    void OnCollisionEnter(Collision other)
    {
        GameObject item = other.gameObject;
        ItemManager itemManager = item.GetComponent<ItemManager>();
        if (other.transform.CompareTag("Sticky") && itemManager.sizeVolume <= size)
        {
            transform.localScale += new Vector3(.01f, .01f, .01f); // 体型变大
            size += itemManager.sizeVolume; 
            speed += itemManager.speedVolume;
            // mainCam.AddDistanceFromBall(.08f);
            //other.enabled = false;
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.transform.SetParent(this.transform);

            //sizeUI.GetComponent<TMP_Text>().text = "Mass: " + Math.Round(size, 2);

           // FindObjectOfType<AudioSource>().PlayOneShot(pickupSound);  //播放音效
        }

    }

}


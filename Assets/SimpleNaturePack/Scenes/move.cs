using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody rigid;
    public Transform pivotCamera;
    public Animator anim;
    public float speed = 10.0f;
    public float speedC = 5.0f;
    public float rotationSpeed = 100f;
    bool walking = false;
    bool waving = false;
    enum cameraS
    {
        free,player
    }
    cameraS state;
    public Transform cameraFree;
    public Transform cam1;
    
    void Start()
    {
        walking = false;
        waving = false;
        state = cameraS.player;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.R) && !walking)
            {
                anim.SetBool("wave", true);
                waving = true;
            }

            if (waving && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !walking)
            {
                anim.SetBool("wave", false);
                anim.SetBool("idle", true);
                waving = false;

            }
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))&& !waving)
            {

            if (Input.GetKey(KeyCode.W) && !waving)
                {
                if (state == cameraS.player) rigid.velocity += transform.forward * (speed * Time.deltaTime);
                    anim.SetBool("walk", true);
                    anim.SetBool("idle", false);
                    walking = true;
                }

                if (Input.GetKey(KeyCode.S) && !waving)
                {
                    if(state == cameraS.player) rigid.velocity += (transform.forward * -1) * (speed * Time.deltaTime);
                    anim.SetBool("walk", true);
                    anim.SetBool("idle", false);
                    walking = true;
                }
            }
            else if (!waving)
            {

                anim.SetBool("walk", false);
                anim.SetBool("idle", true);
                walking = false;
                rigid.velocity = Vector3.zero;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime), Space.World);
            }

        if (state == cameraS.player)
        {

            if (Input.GetKey(KeyCode.Keypad6))
            {
                pivotCamera.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                pivotCamera.Rotate((Vector3.up * -1) * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                pivotCamera.Rotate(pivotCamera.right * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                pivotCamera.Rotate((pivotCamera.right * -1) * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                state = cameraS.free;
                cam1.gameObject.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Y))
            {
                cameraFree.position += cameraFree.forward * (speedC * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.H))
            {
                cameraFree.position += (cameraFree.forward * -1) * (speedC * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.J))
            {
                cameraFree.position += cameraFree.right * (speedC * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.G))
            {
                cameraFree.position += (cameraFree.right * -1) * (speedC * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                cameraFree.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                cameraFree.Rotate((cameraFree.up *-1) * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                cameraFree.Rotate((cameraFree.right * -1) * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                cameraFree.Rotate((cameraFree.right ) * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.Keypad9))
            {
                cameraFree.Rotate((cameraFree.forward * -1) * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKey(KeyCode.Keypad7))
            {
                cameraFree.Rotate((cameraFree.forward) * (rotationSpeed * Time.deltaTime), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = cameraS.player;
                cam1.gameObject.SetActive(true);
            }
        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
}

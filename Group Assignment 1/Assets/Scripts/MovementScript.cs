using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A)) //Press A to move left
        {
            Vector3 position = this.transform.position;
            position.x -=0.1f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D)) //Press D to move right
        {
            Vector3 position = this.transform.position;
            position.x+=0.1f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.W)) //Press W to move forward
        {
            Vector3 position = this.transform.position;
            position.z+=0.1f;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S)) //Press S to move backwards
        {
            Vector3 position = this.transform.position;
            position.z-=0.1f;
            this.transform.position = position;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space)) //Press space to jump
        {
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
        */
    }
}

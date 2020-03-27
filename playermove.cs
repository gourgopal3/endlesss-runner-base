using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    public CharacterController ctrl;
    private float speed = 5f;
    private Vector3 movevector;
    private float verticalvelocity = 0.0f;
    private float gravity = 12f;

    //resrtict player mve during animation
    private float animationduration = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //below if statement is available during first animation duration
        if (Time.time<animationduration) 
        {

            ctrl.Move(Vector3.forward*speed*Time.deltaTime);
            return;
        
        }


        movevector = Vector3.zero;

        if (ctrl.isGrounded)
        {
            verticalvelocity = -0.5f;

        }

        else 
        {
            verticalvelocity -= gravity*Time.deltaTime;

        
        }


        //x---left and right
        movevector.x = Input.GetAxisRaw("Horizontal")*speed;

        //y--up and down
        movevector.y = verticalvelocity;

        //z---forward backward
        movevector.z = speed;

        ctrl.Move(movevector*Time.deltaTime);
    }
}

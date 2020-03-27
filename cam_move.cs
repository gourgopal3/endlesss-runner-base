using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_move : MonoBehaviour
{
    public Transform lookat;
    private Vector3 startofset;
    private Vector3 movevector;

    //Animation
    private float transition = 0f;
    private float animationduration = 3.0f;
    private Vector3 animationoffset = new Vector3(0,5,5);


    // Start is called before the first frame update
    void Start()
    {
        startofset = transform.position - lookat.position;
    }

    // Update is called once per frame
    void Update()
    {
          


        movevector= lookat.position + startofset;

        //restrict camera move
        //X
             //dont move in x it alswys zero so camera will not move in left and right

        movevector.x = 0f;

        //Y
            //move up and down in 3 and 5

        movevector.y = Mathf.Clamp(movevector.y,-10,10);

        //Z
        //dont need for now


        if (transition > 1.0f)
        {
            transform.position = movevector;


        }

        else
        {

            //animation start
            transform.position = Vector3.Lerp(movevector+animationoffset,movevector,transition);
            transition += Time.deltaTime * 1 / animationduration;
            //from start camera willlokk down
            transform.LookAt(lookat.position + Vector3.up);


        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float offset = 5f;

    Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = gameObject.transform.position;

        float playerX = playerTransform.position.x;

        //this should move the camera to keep up with the player
        
        if(playerX < temp.x)
        {//for if the player is going back
            if(temp.x - playerX >= offset)
            {
                temp.x = playerX + offset;
            }
        }
        else if(playerX > temp.x)
        {// for when the player is going forward.
            if(playerX - temp.x >= offset)
            {
                temp.x = playerX - offset;
            }
        }

        if(temp.x <= -4f){
            temp.x = -4f;

        }

        if(temp.x >= 137f){
            temp.x = 137f;

        }

        gameObject.transform.position = temp;

    }
}

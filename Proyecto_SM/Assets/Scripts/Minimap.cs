using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void LateUpdate()
    {


        Vector3 newPosition = player.position;

        newPosition.y = transform.position.y;
        transform.position = newPosition;

        if (transform.position.x < -30)
        {
            transform.position = new Vector3(-30, transform.position.y, transform.position.z);
        }


        if (transform.position.x > 2.5)
        {
            transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
        }

        //transform.position = new Vector3(tr, transform.position.y, 10);


        
        if (transform.position.z > 2.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2.5f);
        }

        
        if (transform.position.z < -2.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.5f);
        }

        
 


    }

}

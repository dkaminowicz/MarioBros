using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

     [SerializeField] private Transform player;
     private float limitCameraX = -10.13919f;
     private float cameraX;

    private void Update()
    {
        cameraX = player.position.x;
        if(player.position.x < limitCameraX)
        {
            cameraX = limitCameraX;
        }
        transform.position = new Vector3(cameraX, transform.position.y, transform.position.z);
    }
}

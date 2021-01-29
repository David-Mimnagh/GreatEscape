using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float cameraOffset = -10.02f;
    public Camera viewCamera;
    public void updateCameraPos(float x, float y)
     {
         float charPosX = x;
         float charPosY = y;
 
         viewCamera.transform.position = new Vector3(charPosX, charPosY, cameraOffset);
 
     }
}

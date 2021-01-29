using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    float cameraOffsetX = 0.62f;
    float cameraOffsetY = -0.571f;
    float cameraOffsetZ = -14.0f;
    public Camera viewCamera;
    public void updateCameraPos(float x, float y)
     {
         float charPosX = x + cameraOffsetX;
         float charPosY = y + cameraOffsetY;
 
         viewCamera.transform.position = new Vector3(charPosX, charPosY, cameraOffsetZ);
 
     }
}

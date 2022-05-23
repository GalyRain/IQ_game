using System;
using UnityEngine;

namespace Game.NewVersion
{
    public class GameController : MonoBehaviour
    {
        float rotationSpeed = 0.02f;

        private void Update()
        {
            OnMouseDrag();
        }

        private void OnMouseDrag()
        {
            float XRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float Yotation = Input.GetAxis("Mouse Y") * rotationSpeed;
            // select the axis by which you want to rotate the GameObject
            // transform.RotateAround (Vector3.down, XRotation);
            // transform.RotateAround (Vector3.right, Yotation);
            transform.Rotate(Vector3.down, 45);
            transform.Rotate(Vector3.right, 180);
        }
        
    }
    
    
}
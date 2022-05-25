using UnityEngine;

namespace Game.GameAndUI
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private Transform target;

        public void RotateY()
        {
            transform.RotateAround(target.position, Vector3.down, 180);
        }
    
        public void RotateZ()
        {
            transform.RotateAround(target.position, Vector3.forward, 45);
        }
    }
}
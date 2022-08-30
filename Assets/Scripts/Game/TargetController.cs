using UnityEngine;

namespace Game
{
    public class TargetController : MonoBehaviour
    {
        [SerializeField] private GameObject block;
        
        private UnityEngine.Camera _camera;
        private Vector3 _blockRotation;
        private Vector3 mousePositionA;
        private Vector3 mousePositionB;
        
        private float _angle;
        
        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            transform.position = block.transform.position;
        }

        private void OnMouseDown()
        { 
            _blockRotation = block.transform.rotation.eulerAngles;
           
            mousePositionA = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void OnMouseDrag()
        {
            mousePositionB = _camera.ScreenToWorldPoint(Input.mousePosition);
            var position = transform.position;

            _angle = Vector2.SignedAngle(mousePositionA - position, mousePositionB - position);

            block.transform.rotation = _blockRotation.y >= 180 ? Quaternion.Euler(0, 180,  - _angle +_blockRotation.z) : Quaternion.Euler(0, 0,  _angle  + _blockRotation.z);
        }
    }
}
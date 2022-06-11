using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class TargetController : MonoBehaviour
    {
        [SerializeField] private GameObject block;
        
        private UnityEngine.Camera _camera;
        private HingeJoint2D _hingeJoint;
        private Vector3 _blockRotation;
        private Vector3 mousePositionA;
        private Vector3 mousePositionB;
        
        private float _angle;
        private float _doubleClickTime = 0.25f;
        private float _lastClickTime;
        
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
            // var position = block.transform.position;
            var position = transform.position;

            _angle = Vector3.SignedAngle(mousePositionA - position,
                mousePositionB - position, - _camera.transform.forward);
            
            if (_blockRotation.y == 180)
            {
                block.transform.rotation = Quaternion.Euler(0, 180,  _angle * 8 +_blockRotation.z);
            }
            else 
            {
                block.transform.rotation = Quaternion.Euler(0, 0,  - _angle * 8 + _blockRotation.z);
            }
        }
    }
}

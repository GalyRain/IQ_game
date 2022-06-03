using UnityEngine;

namespace Game
{
    public class TargetRotation : MonoBehaviour
    {
        private UnityEngine.Camera _camera;
        [SerializeField] private GameObject block;
        private Vector3 _blockRotation;
        private float _angle;
        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void OnMouseDown()
        {
            _blockRotation = block.transform.rotation.eulerAngles;
        }

        private void OnMouseDrag()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var position = block.transform.position;
        
            _angle = Mathf.Atan2(position.x - mousePosition.x, - position.y + mousePosition.y) * Mathf.Rad2Deg;
        
            if (_blockRotation.y is >= 0 and < 1)
            {
                block.transform.rotation = Quaternion.Euler(_blockRotation.x, 0,  _angle);
            }

            if (_blockRotation.y == 180)
            {
                block.transform.rotation = Quaternion.Euler(_blockRotation.x, 180,  - _angle);
            }
        }
    }
}

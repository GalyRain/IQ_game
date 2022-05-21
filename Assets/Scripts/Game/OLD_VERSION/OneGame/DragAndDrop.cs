using UnityEngine;

namespace Game.MoveAndRotateModel
{
    public class DragAndDrop : MonoBehaviour
    {
        private UnityEngine.Camera _camera;
        private Vector3 _offset;

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
        }
        
        private void OnMouseDown()
        {
            _offset = transform.position - _camera.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }

        private void OnMouseDrag()
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = _camera.ScreenToWorldPoint(newPosition) + _offset;
        }
    }
}
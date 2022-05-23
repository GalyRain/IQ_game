using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.GameAndUI
{
    public class GameController : MonoBehaviour, IPointerClickHandler
    {
        private UnityEngine.Camera _camera;
        private Vector3 _offset;
        
        private float _doubleClickTime = 0.25f;
        private float _lastClickTime = 0.0f;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }
   
        public void OnPointerClick(PointerEventData eventData)
        {
            float timeFromLastClick = Time.time - _lastClickTime;
            _lastClickTime = Time.time;

            if (timeFromLastClick < _doubleClickTime)
            {
                transform.GetComponent<Rotation>().RotateY();
            }
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

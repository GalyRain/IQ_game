using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.GameAndUI
{
    public class GameController : MonoBehaviour, IPointerClickHandler
    {
        private UnityEngine.Camera _camera;
        private Vector3 _offset;
        private GameObject _model;
        
        private float _doubleClickTime = 0.25f;
        private float _lastClickTime = 0.0f;
        
        private float minX = 50f;
        private float maxX = 1000f;
        private float minY = 50f;
        private float maxY = 1800f;

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
            
            float positionX = Mathf.Clamp(Input.mousePosition.x, minX, maxX);
            float positionY = Mathf.Clamp(Input.mousePosition.y, minY, maxY);
            _offset = transform.position - _camera.ScreenToWorldPoint(
                new Vector3(positionX, positionY, 10.0f));
            
            RaycastHit2D hit = Physics2D.Raycast(
                _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Block"))
            {
                _model = new GameObject();
                transform.GetComponent<Rotation>().SetActivated();
            }
        }

        private void OnMouseDrag()
        {
            float positionX = Mathf.Clamp(Input.mousePosition.x, minX, maxX);
            float positionY = Mathf.Clamp(Input.mousePosition.y, minY, maxY);
            
            
            Vector3 newPosition = new Vector3(positionX, positionY, 10.0f);
            transform.position = _camera.ScreenToWorldPoint(newPosition) +_offset;
        }
    }
}
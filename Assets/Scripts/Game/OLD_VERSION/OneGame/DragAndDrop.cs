using Game.GameAndUI;
using UnityEngine;

namespace Game.MoveAndRotateModel
{
    public class DragAndDrop : MonoBehaviour
    {
        [SerializeField] private GameObject selectBlock;
        private UnityEngine.Camera _camera;
        private Vector3 _offset;
        
        private float _doubleClickTime = 0.25f;
        private float _lastClickTime = 0.0f;

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(1))
            {
                if (hit.collider != null && hit.collider.CompareTag("Model"))
                {
                    selectBlock = hit.transform.gameObject;
                    hit.collider.GetComponent<Rotation>().RotateZ();
                }
            }
#endif

#if UNITY_ANDROID
            if (Input.touchCount == 2)
            {
                Touch touchA = Input.GetTouch(0);
                Touch touchB = Input.GetTouch(1);
                Vector2 touchADirection = touchA.position - touchA.deltaPosition;
                Vector2 touchBDirection = touchB.position - touchB.deltaPosition;
 
                if (hit.collider != null && hit.collider.CompareTag("Model"))
                {
                    selectBlock = hit.transform.gameObject;
                    float angle = Vector3.SignedAngle(touchA.position - touchB.position,
                        touchADirection - touchBDirection, - _camera.transform.forward);
                    selectBlock.transform.RotateAround(_camera.transform.position, Vector3.forward, angle);
                }
            }
#endif
        }

        private void OnMouseDown()
        {
            _offset = selectBlock.transform.position - _camera.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

            float timeFromLastClick = Time.time - _lastClickTime;
            _lastClickTime = Time.time;

            if (timeFromLastClick < _doubleClickTime)
            {
                selectBlock.transform.GetComponent<Rotation>().RotateY();
            }
        }

        private void OnMouseDrag()
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            selectBlock.transform.position = _camera.ScreenToWorldPoint(newPosition) + _offset;
        }
    }
}
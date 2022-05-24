using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.GameAndUI
{
    public class DragAndDropBlock : MonoBehaviour
    {
        [SerializeField] private GameObject selectBlock;
        
        private UnityEngine.Camera _camera;
        private Vector3 _offset;
        private bool _dragging = false;
        
        private float _doubleClickTime = 0.25f;
        private float _lastClickTime = 0.0f;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }
    
        private void Update () 
        {
            RaycastHit2D hit = Physics2D.Raycast(
                _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
#if UNITY_EDITOR
            DragAndDrop(hit);
            RotateY(hit);
            RotateZ(hit);
#endif
#if UNITY_ANDROID
            DragAndDropAndroid(hit);
            RotateZAndroid(hit);
            RotateYAndroid(hit);
#endif
        }
// PC ------------------------------------------------------------------------------------------------------------------
// PC ------------------------------------------------------------------------------------------------------------------
        private void DragAndDrop(RaycastHit2D hit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider != null && hit.collider.CompareTag("Model"))
                {
                    selectBlock = hit.transform.gameObject;
                    _offset = selectBlock.transform.position - _camera.ScreenToWorldPoint(
                        new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
                }
            }
            if (selectBlock != null)
            {
                Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
                selectBlock.transform.position = _camera.ScreenToWorldPoint(newPosition) + _offset;
            }
            NotActivated(0);
        }

        private void RotateZ(RaycastHit2D hit)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (hit.collider != null && hit.collider.CompareTag("Model"))
                {
                    selectBlock = hit.transform.gameObject;
                    hit.collider.GetComponent<Rotation>().RotateZ();
                }
            }
            NotActivated(1);
        }

        private void RotateY(RaycastHit2D hit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                float timeFromLastClick = Time.time - _lastClickTime;
                _lastClickTime = Time.time;
                if (timeFromLastClick < _doubleClickTime)
                {
                    if (hit.collider != null && hit.collider.CompareTag("Model"))
                    {
                        selectBlock = hit.transform.gameObject;
                        hit.collider.GetComponent<Rotation>().RotateY();
                    }
                }
            }
            NotActivated(1);
        }
        
        private void NotActivated(int mouseButton)
        {
            if (Input.GetMouseButtonUp(mouseButton))
            {
                if (!(selectBlock == null))
                {
                    selectBlock = null;
                }
            }
        } 
        
// Android -------------------------------------------------------------------------------------------------------------
// Android -------------------------------------------------------------------------------------------------------------
        private void DragAndDropAndroid(RaycastHit2D hit)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (hit.collider != null && hit.collider.CompareTag("Model"))
                    {
                        selectBlock = hit.transform.gameObject;
                        _offset = selectBlock.transform.position - _camera.ScreenToWorldPoint(
                            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

                        _dragging = true;
                    }
                }

                if (_dragging && touch.phase == TouchPhase.Moved)
                {
                    Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
                    selectBlock.transform.position = _camera.ScreenToWorldPoint(newPosition) + _offset;
                }

                if (_dragging && touch.phase is TouchPhase.Ended or TouchPhase.Canceled)
                {
                    _dragging = false;
                    if (!(selectBlock == null))
                    {
                        selectBlock = null;
                    }
                }
            }
        }
        
        private void RotateZAndroid(RaycastHit2D hit)
        {
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
        }
        
        private void RotateYAndroid(RaycastHit2D hit)
        {
            if (Input.touchCount == 1)
            {
                float timeFromLastClick = Time.time - _lastClickTime;
                _lastClickTime = Time.time;

                if (timeFromLastClick < _doubleClickTime)
                {
                    if (hit.collider != null && hit.collider.CompareTag("Model"))
                    {
                        selectBlock = hit.transform.gameObject;
                        hit.transform.GetComponent<Rotation>().RotateY();
                    }
                }
            }
        }
    }
}

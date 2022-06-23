using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.Rendering;

namespace Camera
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private GameObject selectBlock;

        private Collider2D _collider;
        private Vector3 _hitPoint;
        
        private UnityEngine.Camera _camera;
        private Rigidbody2D _blockRigidbody;
        private SpringJoint2D _springJoint;
        private Vector2 _offset;
        
        private readonly float _dragSpeed = 10f;
        private int _level = 1;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }
    
        private void Update() 
        {
            RaycastHit2D hit = Physics2D.Raycast(
                _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (Input.GetMouseButtonDown(0) || Input.touches.Any(x => x.phase == TouchPhase.Began))
            {
                if (hit.collider != null && hit.collider.CompareTag("Block"))
                {
                    // if (_springJoint != null) // use joint
                    // {
                    //     Destroy(_springJoint);
                    //     _springJoint = null;
                    // }
                    
                    if (selectBlock != null)
                    {
                        selectBlock.GetComponent<BlockController>().SetNotActivated();
                        selectBlock = null;
                    }

                    selectBlock = hit.transform.gameObject;
                    // _collider = hit.collider; // use joint
                    // _hitPoint = hit.point;

                    selectBlock.GetComponent<BlockController>().SetActivated();
                    
                    selectBlock.GetComponent<SortingGroup>().sortingOrder = _level;
                    _level++;
                    
                    _blockRigidbody = selectBlock.GetComponent<Rigidbody2D>();
                    _blockRigidbody.mass = 1f;
                    _blockRigidbody.freezeRotation = false;
                    
                    _offset = selectBlock.transform.position - _camera.ScreenToWorldPoint(
                        new Vector3(Input.mousePosition.x, Input.mousePosition.y));
                   
                    
                    // Vector3 localHit = selectBlock.transform.InverseTransformPoint(hit.point); // use joint
                    // _springJoint = selectBlock.gameObject.AddComponent<SpringJoint2D>();
                    // _springJoint.connectedBody = null;
                    // _springJoint.enabled = true;
                    // _springJoint.enableCollision = true;
                    // _springJoint.autoConfigureConnectedAnchor = false;
                    // _springJoint.anchor = localHit;
                }

                if (hit.collider == null)
                {
                    if (selectBlock != null)
                    {
                        selectBlock.GetComponent<BlockController>().SetNotActivated();
                        selectBlock = null;
                    }
                }
            }
            
            if (Input.GetMouseButtonUp(0) || Input.touches.Any(x=> x.phase == TouchPhase.Ended))
            {
                if (_blockRigidbody != null)
                {
                    _blockRigidbody.freezeRotation = true;
                    _blockRigidbody.mass = 100f;
                }
                _blockRigidbody = null;
                // Destroy(_springJoint); // use joint
                // _springJoint = null;
            }
        }
        
        private void FixedUpdate()
        {
            if (_blockRigidbody != null)
            {
                Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dir = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y) - _blockRigidbody.position + _offset;
                dir *= _dragSpeed;
                _blockRigidbody.velocity = dir;
            }
            // if (_springJoint != null) // use joint 
            // {
            //     Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            //     Vector2 mouse2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
            
            //     _springJoint.connectedAnchor = mouse2D;
            //     _springJoint.distance = 0f;
            //     _springJoint.dampingRatio = 10000;
            // }
        }
    }
}

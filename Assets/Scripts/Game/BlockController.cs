using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class BlockController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject model;
        
        private Quaternion _rotation;
        private Rigidbody2D _blockRigidbody;
        private HingeJoint2D _hingeJoint;
        
        private float _doubleClickTime = 0.25f;
        private float _lastClickTime;

        private void Start() 
        {
            _blockRigidbody = GetComponent<Rigidbody2D>();
            _rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
    
        public void SetActivated()
        {
            target.transform.position = transform.position;
            target.SetActive(true);
            model.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        
        public void SetNotActivated()
        {
            target.SetActive(false);
            model.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            float timeFromLastClick = Time.time - _lastClickTime;
            _lastClickTime = Time.time;
            
            if (timeFromLastClick < _doubleClickTime)
            {
                // transform.Rotate(Vector3.down, 180);
                // transform.rotation = Quaternion.Euler(0, 180,  0);

                // Quaternion next = Quaternion.RotateTowards(transform.rotation, _rotation, 10.0f * Time.deltaTime);
 
                // _blockRigidbody.MoveRotation(_rotation);
                GetComponent<Rigidbody2D>().AddTorque(180, ForceMode2D.Force);
            }
        }
    }
}
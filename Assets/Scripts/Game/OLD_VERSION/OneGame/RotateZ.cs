using UnityEngine;

namespace Game.MoveAndRotateModel
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class RotateZ : MonoBehaviour
    {
        [SerializeField] private GameObject model;
        [SerializeField] private Transform transformTarget;
        
        private CircleCollider2D _circleCollider2D;
        private Vector3 _rotate;
        private bool _isClick = false;

        private void Start()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
        }
        
        private void OnMouseDown()
        {
            if (_circleCollider2D.enabled)
            {
                _isClick = true;
            }
        }

        private void Update()
        {
            if (_isClick && Input.GetMouseButtonDown(0))
            {
                model.transform.RotateAround(transformTarget.position, Vector3.forward, 0);
                _isClick = false;
            }
        }
    }
}
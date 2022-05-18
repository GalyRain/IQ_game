using UnityEngine;

namespace Game.MoveAndRotateModel
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class RotateZ : MonoBehaviour
    {
        [SerializeField] private GameObject model;
        
        private CircleCollider2D _circleCollider2D;
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
                model.transform.Rotate(new Vector3(0, 0, 45));
                _isClick = false;
            }
        }
    }
}
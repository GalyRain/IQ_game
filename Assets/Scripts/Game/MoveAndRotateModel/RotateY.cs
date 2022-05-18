using UnityEngine;

namespace Game.MoveAndRotateModel
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class RotateY : MonoBehaviour
    {
        [SerializeField] private GameObject model;
        
        private CircleCollider2D _circleCollider2D;
        private bool _isClick = false;
        private Vector3 _scaleChange;

        private void Start()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _scaleChange = new Vector3(-1f, -1f, 1f);
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
                model.transform.localScale = _scaleChange;
                _scaleChange = - _scaleChange;
                _isClick = false;
            }
        }
    }
}
using UnityEngine;

namespace Game.MoveAndRotateModel
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class DragAndDrop : MonoBehaviour
    {
        private bool _dragging = false;
        private Camera _camera;
        private PolygonCollider2D _polygonCollider2D;

        private void Start()
        {
            _polygonCollider2D = GetComponent<PolygonCollider2D>();
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_dragging)
            {
                Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
            }
        }

        private void OnMouseDown()
        {
            _dragging = true;
        }

        private void OnMouseUp()
        {
            _dragging = false;
        }
    }
}
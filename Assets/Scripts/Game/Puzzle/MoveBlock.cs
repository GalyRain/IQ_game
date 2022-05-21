using UnityEngine;
using UnityEngine.Rendering;

namespace Game.Puzzle
{
    public class MoveBlock : MonoBehaviour
    {
        
        [SerializeField] private GameObject selectPiece;
        private UnityEngine.Camera _camera;
        private bool _isFinish;
        private int _level = 1;

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(
                    _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.transform.CompareTag("Puzzle"))
                {
                    selectPiece = hit.transform.gameObject;
                    selectPiece.GetComponent<SortingGroup>().sortingOrder = _level;
                    _level++;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (selectPiece != null)
                {
                    selectPiece = null;
                }
            }
            if (selectPiece != null)
            {
                Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                selectPiece.transform.position = new Vector3(mousePosition.x, mousePosition.y , 0f);
            }
        }
    }
}

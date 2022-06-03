using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.Rendering;

namespace Camera
{
    public class ActivityManager : MonoBehaviour
    {
        [SerializeField] private GameObject selectBlock;
        
        private UnityEngine.Camera _camera;
        private Vector3 _offset;
        private int _level = 1;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }
    
        private void Update() 
        {
            RaycastHit2D hit = Physics2D.Raycast(
                _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (Input.GetMouseButtonDown(0) || Input.touches.Any(x=>x.phase==TouchPhase.Began))
            {
                if (hit.collider != null && hit.collider.CompareTag("Block"))
                {
                    if (selectBlock != null)
                    {
                        selectBlock.transform.GetComponent<BlockManager>().SetNotActivated();
                        selectBlock = null;
                    }
               
                    selectBlock = hit.transform.gameObject;
                    selectBlock.transform.GetComponent<BlockManager>().SetActivated();
                    selectBlock.GetComponent<SortingGroup>().sortingOrder = _level;
                    _level++;
                }

                if (hit.collider == null)
                {
                    if (selectBlock != null)
                    {
                        selectBlock.transform.GetComponent<BlockManager>().SetNotActivated();
                        selectBlock = null;
                    }
                }
            }
        }
    }
}

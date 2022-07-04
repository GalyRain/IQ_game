using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class BlockController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject model;
        
        private float _doubleClickTime = 0.25f;
        private float _lastClickTime;
        private bool _scale;

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
                if (!_scale)
                {
                    Debug.Log(_scale);
                    transform.localScale = new Vector3(-1,1,1);
                    _scale = true;
                    return;
                }
                if (_scale)
                {
                    transform.localScale = new Vector3(1,1,1);
                    _scale = false;
                }
            }
            // if (eventData.clickCount == 2) // doesn't work on smartphone
            // {
            //     transform.Rotate(Vector3.down, 180);
            // }
        }
    }
}
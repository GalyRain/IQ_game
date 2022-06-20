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
                transform.Rotate(Vector3.down, 180);
            }
            // if (eventData.clickCount == 2) // баг в unity не работает на смартфоне
            // {
            //     transform.Rotate(Vector3.down, 180);
            // }
        }
    }
}
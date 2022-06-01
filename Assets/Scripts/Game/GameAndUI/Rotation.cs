using Unity.Mathematics;
using UnityEngine;

namespace Game.GameAndUI
{
    public class Rotation : MonoBehaviour {
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject center;
        [SerializeField] private GameObject model;
        private bool _isActive;

        public void RotateY()
        {
            transform.RotateAround(center.transform.position, Vector3.down, 180);
        }
    
        public void RotateZ()
        {
            if (_isActive)
            {
                float _angle = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
                transform.RotateAround(center.transform.position, Vector3.forward, _angle);
            }
        }
        
        public void SetActivated()
        {
            target.SetActive(true);
            _isActive = true;
            model.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        
        public void SetNotActivated()
        {
            target.SetActive(false);
            _isActive = false;
            model.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
using UnityEngine;
using UnityEngine.Rendering;

namespace Game
{
    public class BlockManager : MonoBehaviour {
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject center;
        [SerializeField] private GameObject model;

        public void Inversion()
        {
            transform.RotateAround(center.transform.position, Vector3.down, 180);
        }
    
        public void SetActivated()
        {
            target.SetActive(true);
            model.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        
        public void SetNotActivated()
        {
            target.SetActive(false);
            model.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
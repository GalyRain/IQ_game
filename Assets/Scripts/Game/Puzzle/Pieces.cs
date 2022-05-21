using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace Game.Puzzle
{
    public class Pieces : MonoBehaviour
    {
    
        private Vector3 _rightPosition;
        private bool _selected;

        private void Start()
        {
            _rightPosition = transform.position;
            transform.position = new Vector3(Random.Range(0f, 7f), Random.Range(-4f, 4f), 0f);
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _rightPosition) < 0.5f)
            {
                if (!_selected) // если на месте то уже нельзя взять 
                {
                    transform.position = _rightPosition;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }
}

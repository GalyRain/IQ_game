using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class GamePlay : MonoBehaviour
    {
        // [SerializeField] private GameObject finishGame;
        // [SerializeField] private GameObject blockOne;
        // [SerializeField] private GameObject blockTwo;
        // [SerializeField] private GameObject blockThree;
        // [SerializeField] private GameObject blockFour;

        private bool _blockOneIsActivate;
        private bool _blockTwoIsActivate;
        private bool _blockThreeIsActivate;
        private bool _blockFourIsActivate;

        private void Update()
        {
            if (_blockOneIsActivate && _blockTwoIsActivate && _blockThreeIsActivate && _blockFourIsActivate)
            {
                Debug.Log("Finish");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag($"BlockOne"))
            {
                Debug.Log("_blockOneIsActivate");
                _blockOneIsActivate = true;
            }
            if (other.gameObject.CompareTag($"BlockTwo"))
            {
                Debug.Log("_blockTwoIsActivate");
                _blockTwoIsActivate = true;
            }
            if (other.gameObject.CompareTag($"BlockThree"))
            {
                Debug.Log("_blockThreeIsActivate");
                _blockThreeIsActivate = true;
            }
            if (other.gameObject.CompareTag($"BlockFour"))
            {
                Debug.Log("_blockFourIsActivate");
                _blockFourIsActivate = true;
            }
        }
    }
}

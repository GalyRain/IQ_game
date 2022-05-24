using UnityEngine;

namespace Game.GameAndUI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject blockOne;
        [SerializeField] private GameObject blockTwo;
        [SerializeField] private GameObject blockThree;
        [SerializeField] private GameObject blockFour;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject gameBlocks;
        [SerializeField] private GameObject wrongText;
        private bool _isOneTwo = false, _isOneThree = false, _isOneFour = false, _isTwoThree = false, 
            _isTwoFour = false, _isThreeFour, _isRight = false;
    
        private bool CheckPosition()
        {
            if (Vector3.Distance(blockOne.transform.position, blockTwo.transform.position) < 10.10f
                && Vector3.Distance(blockOne.transform.position, blockTwo.transform.position) > 9.90f)
            {
                _isOneTwo = true;
                // Debug.Log(isOneTwo);
            }
        
            if (Vector3.Distance(blockOne.transform.position, blockThree.transform.position) < 10.20f
                && Vector3.Distance(blockOne.transform.position, blockThree.transform.position) > 10.00f)
            {
                _isOneThree = true;
                // Debug.Log(isOneThree);
            }
            if (Vector3.Distance(blockOne.transform.position, blockFour.transform.position) < 3.25f
                && Vector3.Distance(blockOne.transform.position, blockFour.transform.position) > 3.05f)
            {
                _isOneFour = true;
                // Debug.Log(isOneFour);
            }
            if (Vector3.Distance(blockTwo.transform.position, blockThree.transform.position) < 14.40f
                && Vector3.Distance(blockTwo.transform.position, blockThree.transform.position) > 14.20f)
            {
                _isTwoThree = true;
                // Debug.Log(isTwoThree);
            }
            if (Vector3.Distance(blockTwo.transform.position, blockFour.transform.position) < 13.15f
                && Vector3.Distance(blockTwo.transform.position, blockFour.transform.position) > 12.95f)
            {
                _isTwoFour = true;
                // Debug.Log(isThreeFour);
            }
            if (Vector3.Distance(blockThree.transform.position, blockFour.transform.position) < 9.70f
                && Vector3.Distance(blockThree.transform.position, blockFour.transform.position) > 9.50f)
            {
                _isThreeFour = true;
                // Debug.Log(isThreeFour);
            }

            if (_isOneTwo && _isOneThree && _isOneFour && _isTwoThree && _isTwoFour && _isThreeFour)
            {
                _isRight = true;
            }
            return _isRight;
        }

        public void FinishButton()
        {
            Debug.Log(Vector3.Distance(blockOne.transform.position, blockTwo.transform.position));
            Debug.Log(Vector3.Distance(blockOne.transform.position, blockThree.transform.position));
            Debug.Log(Vector3.Distance(blockOne.transform.position, blockFour.transform.position));
            Debug.Log(Vector3.Distance(blockTwo.transform.position, blockThree.transform.position));
            Debug.Log(Vector3.Distance(blockTwo.transform.position, blockFour.transform.position));
            Debug.Log(Vector3.Distance(blockThree.transform.position, blockFour.transform.position));
            Debug.Log(CheckPosition());
            if (CheckPosition())
            {
                startPanel.SetActive(true);
                gamePanel.SetActive(false);
                gameBlocks.SetActive(false);
                wrongText.SetActive(false);
            }
            else
            {
                wrongText.SetActive(true);
            }
        }
    
        public void StartButton()
        {
            gamePanel.SetActive(true);
            startPanel.SetActive(false);
            gameBlocks.SetActive(true);
            RandomPosition();
            CheckFalse();
        }
        
        public void BackButton()
        {
            startPanel.SetActive(true);
            gamePanel.SetActive(false);
            gameBlocks.SetActive(false);
            wrongText.SetActive(false);
        }
        
        public void ExitButton()
        {
            Application.Quit();
        }
    
        private void RandomPosition()
        {
            blockOne.transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 2f), 0f);
            blockTwo.transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 2f), 0f);
            blockThree.transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 2f), 0f);
            blockFour.transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 2f), 0f);
        }

        private void CheckFalse()
        {
            _isRight = false;
            _isOneTwo = false;
            _isOneThree = false;
            _isOneFour = false;
            _isTwoThree = false;
            _isTwoFour = false;
            _isThreeFour = false;
        }
    }
}

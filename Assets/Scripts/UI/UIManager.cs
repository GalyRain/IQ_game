using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject helperBloks;
        [SerializeField] private GameObject blockOne;
        [SerializeField] private GameObject blockTwo;
        [SerializeField] private GameObject blockThree;
        [SerializeField] private GameObject blockFour;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject rulesPanel;
        [SerializeField] private GameObject rulesText;
        [SerializeField] private GameObject gameBlocks;
        [SerializeField] private GameObject wrongText;
        [SerializeField] private GameObject wonText;

        private bool _isOneTwo = false, _isOneThree = false, _isOneFour = false, _isTwoThree = false, 
            _isTwoFour = false, _isThreeFour, _isRight = false;
        private bool _isRullestVisible = false;
    
        private bool CheckPosition()
        {
            if (Vector3.Distance(blockOne.transform.position, blockTwo.transform.position) < 7.0f
                && Vector3.Distance(blockOne.transform.position, blockTwo.transform.position) > 6.6f)
            {
                _isOneTwo = true;
                Debug.Log(_isOneTwo);
            }
        
            if (Vector3.Distance(blockOne.transform.position, blockThree.transform.position) < 6.8f
                && Vector3.Distance(blockOne.transform.position, blockThree.transform.position) > 6.3f)
            {
                _isOneThree = true;
                Debug.Log(_isOneThree);
            }
            if (Vector3.Distance(blockOne.transform.position, blockFour.transform.position) < 3.4f
                && Vector3.Distance(blockOne.transform.position, blockFour.transform.position) > 3.0f)
            {
                _isOneFour = true;
                Debug.Log(_isOneFour);
            }
            if (Vector3.Distance(blockTwo.transform.position, blockThree.transform.position) < 7.2f
                && Vector3.Distance(blockTwo.transform.position, blockThree.transform.position) > 6.8f)
            {
                _isTwoThree = true;
                Debug.Log(_isTwoThree);
            }
            if (Vector3.Distance(blockTwo.transform.position, blockFour.transform.position) < 6.2f
                && Vector3.Distance(blockTwo.transform.position, blockFour.transform.position) > 5.8f)
            {
                _isTwoFour = true;
                Debug.Log(_isTwoFour);
            }
            if (Vector3.Distance(blockThree.transform.position, blockFour.transform.position) < 3.6f
                && Vector3.Distance(blockThree.transform.position, blockFour.transform.position) > 3.2f)
            {
                _isThreeFour = true;
                Debug.Log(_isThreeFour);
            }

            if (_isOneTwo && _isOneThree && _isOneFour && _isTwoThree && _isTwoFour && _isThreeFour)
            {
                _isRight = true;
            }
            return _isRight;
        }

        public void CheckButton()
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
                wrongText.SetActive(false);
                wonText.SetActive(true);
            }
            else
            {
                wonText.SetActive(false);
                wrongText.SetActive(true);
            }
        }
    
        public void StartButton()
        {
            startPanel.SetActive(false);
            rulesPanel.SetActive(false);
            wrongText.SetActive(false);
            wonText.SetActive(false);
            gamePanel.SetActive(true);
            gameBlocks.SetActive(true);
            RandomPosition();
            CheckFalse();
        }
        
        public void BackButton()
        {
            gamePanel.SetActive(false);
            rulesPanel.SetActive(false);
            gameBlocks.SetActive(false);
            wrongText.SetActive(false);
            startPanel.SetActive(true);
            helperBloks.SetActive(false);
            rulesText.SetActive(false);
            _isRullestVisible = false;
        }
        
        public void RulesButton()
        {
            startPanel.SetActive(false);
            rulesPanel.SetActive(true);
        }
        
        public void GameRulesButton()
        {
            if (!_isRullestVisible) 
            {
                rulesText.SetActive(true);
                gameBlocks.SetActive(false);
            } 
            if (_isRullestVisible) 
            {
                rulesText.SetActive(false);
                gameBlocks.SetActive(true);
            } 
            _isRullestVisible = !_isRullestVisible;    
        }

        public void GameHelpButton()
        {
            helperBloks.SetActive(true); 
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    
        private void RandomPosition()
        {
            blockOne.transform.rotation = Quaternion.Euler(0, 0, 0);
            blockTwo.transform.rotation = Quaternion.Euler(0, 0, 0);
            blockThree.transform.rotation = Quaternion.Euler(0, 0, 0);
            blockFour.transform.rotation = Quaternion.Euler(0, 0, 0);
            blockOne.transform.position = new Vector3(Random.Range(-6f, 0f), Random.Range(0f, 8f), 0f);
            blockTwo.transform.position = new Vector3(Random.Range(-6f, 0f), Random.Range(-8f, 0f), 0f);
            blockThree.transform.position = new Vector3(Random.Range(0f, 6f), Random.Range(0f, 8f), 0f);
            blockFour.transform.position = new Vector3(Random.Range(0, 6f), Random.Range(-8f, 0f), 0f);
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
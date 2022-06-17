using System.Collections;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject blockOne;
        [SerializeField] private GameObject blockTwo;
        [SerializeField] private GameObject blockThree;
        [SerializeField] private GameObject blockFour;
        [SerializeField] private GameObject modelOne;
        [SerializeField] private GameObject modelTwo;
        [SerializeField] private GameObject modelThree;
        [SerializeField] private GameObject modelFour;
        [SerializeField] private GameObject helperBlock;
        [SerializeField] private GameObject helperModel;
        [SerializeField] private GameObject helpModelOne;
        [SerializeField] private GameObject helpModelTwo;
        [SerializeField] private GameObject helpModelThree;
        [SerializeField] private GameObject helpModelFour;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject rulesPanel;
        [SerializeField] private GameObject rulesText;
        [SerializeField] private GameObject gameBlocks;
        [SerializeField] private GameObject wrongText;
        [SerializeField] private GameObject wonText;

        private bool _isOneTwo = false, _isOneThree = false, _isOneFour = false, _isTwoThree = false, 
            _isTwoFour = false, _isThreeFour, _isRight = false;
        private bool _isRulesVisible = false, _isHelpVisible = false, _isHelpBlockVisible = false;

        private MeshRenderer _spriteOne, _spriteTwo, _spriteThree, _spriteFour, _spriteHelpOne, _spriteHelpTwo,
            _spriteHelpThree, _spriteHelpFour;
    
        private void Start()
        {
            _spriteOne = modelOne.GetComponent<MeshRenderer>();
            _spriteTwo = modelTwo.GetComponent<MeshRenderer>();
            _spriteThree = modelThree.GetComponent<MeshRenderer>();
            _spriteFour = modelFour.GetComponent<MeshRenderer>();
            
            _spriteHelpOne = helpModelOne.GetComponent<MeshRenderer>();
            _spriteHelpTwo = helpModelTwo.GetComponent<MeshRenderer>();
            _spriteHelpThree = helpModelThree.GetComponent<MeshRenderer>();
            _spriteHelpFour = helpModelFour.GetComponent<MeshRenderer>();
        }
        
        private bool CheckPosition()
        {
            if (Vector3.Distance(blockOne.transform.position, blockTwo.transform.position) < 7.1f
                && Vector3.Distance(blockOne.transform.position, blockTwo.transform.position) > 6.6f)
            {
                _isOneTwo = true;
                Debug.Log(_isOneTwo);
            }
        
            if (Vector3.Distance(blockOne.transform.position, blockThree.transform.position) < 6.9f
                && Vector3.Distance(blockOne.transform.position, blockThree.transform.position) > 6.3f)
            {
                _isOneThree = true;
                Debug.Log(_isOneThree);
            }
            if (Vector3.Distance(blockOne.transform.position, blockFour.transform.position) < 3.5f
                && Vector3.Distance(blockOne.transform.position, blockFour.transform.position) > 3.0f)
            {
                _isOneFour = true;
                Debug.Log(_isOneFour);
            }
            if (Vector3.Distance(blockTwo.transform.position, blockThree.transform.position) < 7.3f
                && Vector3.Distance(blockTwo.transform.position, blockThree.transform.position) > 6.8f)
            {
                _isTwoThree = true;
                Debug.Log(_isTwoThree);
            }
            if (Vector3.Distance(blockTwo.transform.position, blockFour.transform.position) < 6.3f
                && Vector3.Distance(blockTwo.transform.position, blockFour.transform.position) > 5.8f)
            {
                _isTwoFour = true;
                Debug.Log(_isTwoFour);
            }
            if (Vector3.Distance(blockThree.transform.position, blockFour.transform.position) < 3.7f
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
            _isHelpVisible = false;
        }
        
        public void BackButton()
        {
            gamePanel.SetActive(false);
            rulesPanel.SetActive(false);
            gameBlocks.SetActive(false);
            wrongText.SetActive(false);
            startPanel.SetActive(true);
            helperModel.SetActive(false);
            rulesText.SetActive(false);
            _isRulesVisible = false;
            _isHelpVisible = false;
        }
        
        public void RulesButton()
        {
            startPanel.SetActive(false);
            rulesPanel.SetActive(true);
        }
        
        public void GameRulesButton()
        {
            if (!_isRulesVisible) 
            {
                rulesText.SetActive(true);
                gameBlocks.SetActive(false);
                helperBlock.SetActive(false);
                
            } 
            if (_isRulesVisible) 
            {
                rulesText.SetActive(false);
                gameBlocks.SetActive(true);
                helperBlock.SetActive(true);
            } 
            _isRulesVisible = !_isRulesVisible;    
        }

        public void GameHelpButton()
        {
            if (!_isHelpVisible && !_isHelpBlockVisible)
            {
                helperModel.SetActive(true);
                _isHelpVisible = true;
                return;
            }

            if (_isHelpVisible)
            {
                if (_isHelpBlockVisible)
                {
                    StartCoroutine("VisibleSpriteBlock");
                    StartCoroutine("InVisibleSpriteBlockHelper");
                    _isHelpVisible = false;
                    return;
                }
                if (!_isHelpBlockVisible)
                {
                    StartCoroutine("InVisibleSpriteBlock");
                    StartCoroutine("VisibleSpriteBlockHelper");
                    _isHelpBlockVisible = true;
                    return;
                }
            }
            
            if (!_isHelpVisible && _isHelpBlockVisible)
            {
                helperModel.SetActive(false);
                _isHelpBlockVisible = false;
            }
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

        IEnumerator VisibleSpriteBlock()
        {
            for (float f = 0.05f; f <= 1; f += 0.05f)
            {
                Color colorOne = _spriteOne.material.color;
                Color colorTwo = _spriteTwo.material.color;
                Color colorThree = _spriteThree.material.color;
                Color colorFour = _spriteFour.material.color;
                colorOne.a = f;
                colorTwo.a = f;
                colorThree.a = f;
                colorFour.a = f;
                _spriteOne.material.color = colorOne;
                _spriteTwo.material.color = colorTwo;
                _spriteThree.material.color = colorThree;
                _spriteFour.material.color = colorFour;
                yield return new WaitForSeconds(0.05f);
            }
        }
        
        IEnumerator InVisibleSpriteBlock()
        {
            for (float f = 1f; f >= -0.05; f -= 0.05f)
            {
                Color colorOne = _spriteOne.material.color;
                Color colorTwo = _spriteTwo.material.color;
                Color colorThree = _spriteThree.material.color;
                Color colorFour = _spriteFour.material.color;
                colorOne.a = f;
                colorTwo.a = f;
                colorThree.a = f;
                colorFour.a = f;
                _spriteOne.material.color = colorOne;
                _spriteTwo.material.color = colorTwo;
                _spriteThree.material.color = colorThree;
                _spriteFour.material.color = colorFour;
                yield return new WaitForSeconds(0.05f);
            }
        }

        IEnumerator VisibleSpriteBlockHelper()
        {
            for (float f = 0.05f; f <= 1; f += 0.05f)
            {
                Color colorOneHelp = _spriteHelpOne.material.color;
                Color colorTwoHelp = _spriteHelpTwo.material.color;
                Color colorThreeHelp = _spriteHelpThree.material.color;
                Color colorFourHelp = _spriteHelpFour.material.color;
                colorOneHelp.a = f;
                colorTwoHelp.a = f;
                colorThreeHelp.a = f;
                colorFourHelp.a = f;
                _spriteHelpOne.material.color = colorOneHelp;
                _spriteHelpTwo.material.color = colorTwoHelp;
                _spriteHelpThree.material.color = colorThreeHelp;
                _spriteHelpFour.material.color = colorFourHelp;
                yield return new WaitForSeconds(0.05f);
            }
        }
        
        IEnumerator InVisibleSpriteBlockHelper()
        {
            for (float f = 1f; f >= -0.05; f -= 0.05f)
            {
                Color colorOneHelp = _spriteHelpOne.material.color;
                Color colorTwoHelp = _spriteHelpTwo.material.color;
                Color colorThreeHelp = _spriteHelpThree.material.color;
                Color colorFourHelp = _spriteHelpFour.material.color;
                colorOneHelp.a = f;
                colorTwoHelp.a = f;
                colorThreeHelp.a = f;
                colorFourHelp.a = f;
                _spriteHelpOne.material.color = colorOneHelp;
                _spriteHelpTwo.material.color = colorTwoHelp;
                _spriteHelpThree.material.color = colorThreeHelp;
                _spriteHelpFour.material.color = colorFourHelp;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
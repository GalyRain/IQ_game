using System.Collections;
using Data;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private GameObject levelOneGame;
        [SerializeField] private GameObject levelTwoGame;
        
        [Header("Level data")]
        [SerializeField] private LevelInfo levelOne;
        [SerializeField] private LevelInfo levelTwo;
        
        [Header("Setting")]
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject levelsPanel;
        [SerializeField] private GameObject rulesPanel;
        [SerializeField] private GameObject gamePanel;
        
        [Header("Game")]
        [SerializeField] private GameObject gameBlock;
        [SerializeField] private GameObject rulesText;
        [SerializeField] private GameObject wrongText;
        [SerializeField] private GameObject wonText;
        [SerializeField] private GameObject checkButton;
        [SerializeField] private GameObject continueButton;

        private UILevelController _uiLevelController;
        private LevelInfo levelInfo;

        private bool _isOneTwo, _isOneFive, _isTwoThree, _isThreeFour, _isFourFive, _isFourOne, _isRight;
        private bool _isRulesVisible, _isHelpVisible, _isHelpBlockVisible;

        private MeshRenderer _spriteOne, _spriteTwo, _spriteThree, _spriteFour, _spriteFive,
            _spriteHelpOne, _spriteHelpTwo, _spriteHelpThree, _spriteHelpFour, _spriteHelpFive;

        private Color colorOne, colorTwo, colorThree, colorFour, colorFive,
            colorOneHelp, colorTwoHelp, colorThreeHelp, colorFourHelp, colorFiveHelp;
    
        private void GetComponent()
        {
            _spriteOne = levelInfo.blockOne.GetComponentInChildren<MeshRenderer>();
            _spriteTwo = levelInfo.blockTwo.GetComponentInChildren<MeshRenderer>();
            _spriteThree = levelInfo.blockThree.GetComponentInChildren<MeshRenderer>();
            _spriteFour = levelInfo.blockFour.GetComponentInChildren<MeshRenderer>();
            _spriteFive = levelInfo.blockFive.GetComponentInChildren<MeshRenderer>();
            
            _spriteHelpOne = levelInfo.helpModelOne.GetComponent<MeshRenderer>();
            _spriteHelpTwo = levelInfo.helpModelTwo.GetComponent<MeshRenderer>();
            _spriteHelpThree = levelInfo.helpModelThree.GetComponent<MeshRenderer>();
            _spriteHelpFour = levelInfo.helpModelFour.GetComponent<MeshRenderer>();
            _spriteHelpFive = levelInfo.helpModelFive.GetComponent<MeshRenderer>();
            
            colorOneHelp = _spriteHelpOne.material.color;
            colorTwoHelp = _spriteHelpTwo.material.color;
            colorThreeHelp = _spriteHelpThree.material.color;
            colorFourHelp = _spriteHelpFour.material.color;
            colorFiveHelp = _spriteHelpFive.material.color;
            
            colorOne = _spriteOne.material.color;
            colorTwo = _spriteTwo.material.color;
            colorThree = _spriteThree.material.color;
            colorFour = _spriteFour.material.color;
            colorFive = _spriteFive.material.color;
        }
        
        private bool CheckPosition()
        {
            float[] values = DataGame.CheckDistance(levelInfo.levelNumber);
            if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) < values[0]
                && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) > values[1])
            {
                _isOneTwo = true;
            }
            if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFive.transform.position) < values[2]
                && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFive.transform.position) > values[3])
            {
                _isOneFive = true;
                
            }
            if (Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) < values[4]
                && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) > values[5])
            {
                _isTwoThree = true;
            }
            if (Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[6]
                && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[7])
            {
                _isThreeFour = true;
            }
            if (Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) < values[8]
                && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) > values[9])
            {
                _isFourFive = true;
            }
            if (Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockOne.transform.position) < values[10]
                && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockOne.transform.position) > values[11])
            {
                _isFourOne = true; 
            }

            Debug.Log("_isOneTwo" + _isOneTwo);
            Debug.Log("_isOneFive" + _isOneFive);
            Debug.Log("_isTwoThree" + _isTwoThree);
            Debug.Log("_isThreeFour" + _isThreeFour);
            Debug.Log("_isFourFive" + _isFourFive);
            Debug.Log("_isFourOne" + _isFourOne); 
            
            if (_isOneTwo && _isOneFive && _isTwoThree && _isThreeFour && _isFourFive && _isFourOne)
            {
                _isRight = true;
            }
            return _isRight;
        }
        
        public void CheckButton()
        {
            Debug.Log(Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position));
            Debug.Log(Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFive.transform.position));
            Debug.Log(Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position));
            Debug.Log(Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position));
            Debug.Log(Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position));
            Debug.Log(Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockOne.transform.position));
            if (CheckPosition())
            {
                wrongText.SetActive(false);
                wonText.SetActive(true);
                StartCoroutine(nameof(InVisibleSpriteBlock));
                StartCoroutine(nameof(VisibleSpriteBlockHelper));
                checkButton.SetActive(false);
                continueButton.SetActive(true);
                UILevelController.LevelComplete = levelInfo.levelNumber;
            }
            else
            {
                wonText.SetActive(false);
                wrongText.SetActive(true);
            }
        }

        public void SelectOne()
        {
            levelInfo = levelOne;
            GetComponent();
        }
        
        public void SelectTwo()
        {
            levelInfo = levelTwo;
            GetComponent();
        }
        
        public void SelectLevel()
        {
            rulesPanel.SetActive(false);
            startPanel.SetActive(false);
            gameBlock.SetActive(true);
            wrongText.SetActive(false);
            wonText.SetActive(false);
            checkButton.SetActive(true);
            continueButton.SetActive(false);
            
            CheckFalse();
            _isHelpVisible = false;
        }

        public void BackButton()
        {
            RandomPosition();
            SetColorValue();
            levelsPanel.SetActive(true);
            gamePanel.SetActive(false);
            rulesPanel.SetActive(false);
            
            checkButton.SetActive(true);
            continueButton.SetActive(false);
            
            levelInfo.helperModel.SetActive(false);
            wrongText.SetActive(false);
            rulesText.SetActive(false);
            
            _isRulesVisible = false;
            _isHelpVisible = false;
            _isHelpBlockVisible = false;
        }

        public void GameRulesButton()
        {
            switch (_isRulesVisible)
            {
                case false:
                    rulesText.SetActive(true);
                    gameBlock.SetActive(false);
                    levelInfo.helperView.SetActive(false);
                    break;
                case true:
                    rulesText.SetActive(false);
                    gameBlock.SetActive(true);
                    levelInfo.helperView.SetActive(true);
                    break;
            }

            _isRulesVisible = !_isRulesVisible;
        }

        public void GameHelpButton()
        {
            if (!_isHelpVisible && !_isHelpBlockVisible)
            {
                levelInfo.helperModel.SetActive(true);
                _isHelpVisible = true;
                return;
            }

            if (_isHelpVisible)
            {
                switch (_isHelpBlockVisible)
                {
                    case true:
                        StartCoroutine(nameof(VisibleSpriteBlock));
                        StartCoroutine(nameof(InVisibleSpriteBlockHelper));
                        _isHelpVisible = false;
                        return;
                    case false:
                        StartCoroutine(nameof(InVisibleSpriteBlock));
                        StartCoroutine(nameof(VisibleSpriteBlockHelper));
                        _isHelpBlockVisible = true;
                        return;
                }
            }
            
            if (!_isHelpVisible && _isHelpBlockVisible)
            {
                levelInfo.helperModel.SetActive(false);
                _isHelpBlockVisible = false;
            }
        }

        public void ExitButton()
        {
            Application.Quit();
        }
        
        public void ContinueButton()
        {
            switch (UILevelController.LevelComplete)
            {
                case 0:
                    levelOneGame.SetActive(true);
                    SelectOne();
                    break;
                case 1:
                    levelOneGame.SetActive(false);
                    levelTwoGame.SetActive(true);
                    SelectTwo();
                    break;
            }
        }
    
        private void RandomPosition()
        {
            levelInfo.blockOne.transform.rotation = Quaternion.Euler(0, 0, 0);
            levelInfo.blockTwo.transform.rotation = Quaternion.Euler(0, 0, 0);
            levelInfo.blockThree.transform.rotation = Quaternion.Euler(0, 0, 0);
            levelInfo.blockFour.transform.rotation = Quaternion.Euler(0, 0, 0);
            
            levelInfo.blockOne.transform.position = new Vector3(Random.Range(-6f, 0f), Random.Range(0f, 8f), 0f);
            levelInfo.blockTwo.transform.position = new Vector3(Random.Range(-6f, 0f), Random.Range(-8f, 0f), 0f);
            levelInfo.blockThree.transform.position = new Vector3(Random.Range(0f, 6f), Random.Range(0f, 8f), 0f);
            levelInfo.blockFour.transform.position = new Vector3(Random.Range(0, 6f), Random.Range(-8f, 0f), 0f);
        }

        private void CheckFalse()
        {
            _isRight = false;
            _isOneTwo = false;
            _isOneFive = false;
            _isTwoThree = false;
            _isThreeFour = false;
            _isFourFive = false;
            _isFourOne = false;
        }

        IEnumerator VisibleSpriteBlock()
        {
            for (float f = 1f; f <= 1; f += 0.1f)
            {
                colorOne = _spriteOne.material.color;
                colorTwo = _spriteTwo.material.color;
                colorThree = _spriteThree.material.color;
                colorFour = _spriteFour.material.color;
                colorFive = _spriteFive.material.color;
                
                colorOne.a = f;
                colorTwo.a = f;
                colorThree.a = f;
                colorFour.a = f;
                colorFive.a = f;
                
                SetColor(_spriteOne, colorOne);
                SetColor(_spriteTwo, colorTwo);
                SetColor(_spriteThree, colorThree);
                SetColor(_spriteFour, colorFour);
                SetColor(_spriteFive, colorFive);
                
                yield return new WaitForSeconds(0.1f);
            }
        }
        
        IEnumerator InVisibleSpriteBlock()
        {
            for (float f = 1f; f >= -0.1; f -= 0.1f)
            {
                colorOne = _spriteOne.material.color;
                colorTwo = _spriteTwo.material.color;
                colorThree = _spriteThree.material.color;
                colorFour = _spriteFour.material.color;
                colorFive = _spriteFive.material.color;
                
                colorOne.a = f;
                colorTwo.a = f;
                colorThree.a = f;
                colorFour.a = f;
                colorFive.a = f;
                
                SetColor(_spriteOne, colorOne);
                SetColor(_spriteTwo, colorTwo);
                SetColor(_spriteThree, colorThree);
                SetColor(_spriteFour, colorFour);
                SetColor(_spriteFive, colorFive);
                
                yield return new WaitForSeconds(0.1f);
            }
        }

        IEnumerator VisibleSpriteBlockHelper()
        {
            for (float f = 0.1f; f <= 1; f += 0.1f)
            {
                colorOneHelp = _spriteHelpOne.material.color;
                colorTwoHelp = _spriteHelpTwo.material.color;
                colorThreeHelp = _spriteHelpThree.material.color;
                colorFourHelp = _spriteHelpFour.material.color;
                colorFiveHelp = _spriteHelpFive.material.color;
                
                colorOneHelp.a = f;
                colorTwoHelp.a = f;
                colorThreeHelp.a = f;
                colorFourHelp.a = f;
                colorFiveHelp.a = f;
                
                SetColor(_spriteHelpOne, colorOneHelp);
                SetColor(_spriteHelpTwo, colorTwoHelp);
                SetColor(_spriteHelpThree, colorThreeHelp);
                SetColor(_spriteHelpFour, colorFourHelp);
                SetColor(_spriteHelpFive, colorFiveHelp);
                
                yield return new WaitForSeconds(0.1f);
            }
        }
        
        IEnumerator InVisibleSpriteBlockHelper()
        {
            for (float f = 1f; f >= -0.1; f -= 0.1f)
            {
                colorOneHelp = _spriteHelpOne.material.color;
                colorTwoHelp = _spriteHelpTwo.material.color;
                colorThreeHelp = _spriteHelpThree.material.color;
                colorFourHelp = _spriteHelpFour.material.color;
                colorFiveHelp = _spriteHelpFive.material.color;
                
                colorOneHelp.a = f;
                colorTwoHelp.a = f;
                colorThreeHelp.a = f;
                colorFourHelp.a = f;
                colorFiveHelp.a = f;
                
                SetColor(_spriteHelpOne, colorOneHelp);
                SetColor(_spriteHelpTwo, colorTwoHelp);
                SetColor(_spriteHelpThree, colorThreeHelp);
                SetColor(_spriteHelpFour, colorFourHelp);
                SetColor(_spriteHelpFive, colorFiveHelp);
                
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void SetColorValue()
        {
            StartCoroutine(nameof(VisibleSpriteBlock));
            StartCoroutine(nameof(InVisibleSpriteBlockHelper));
        }

        private static void SetColor(Renderer renderer, Color color)
        {
            renderer.material.color = color;
        }
    }
}
using System.Collections;
using Data;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private GameObject level1Game;
        [SerializeField] private GameObject level2Game;
        [SerializeField] private GameObject level3Game;
        [SerializeField] private GameObject level4Game;
        
        [Header("Level data info")]
        [SerializeField] private LevelInfo level1Info;
        [SerializeField] private LevelInfo level2Info;
        [SerializeField] private LevelInfo level3Info;
        [SerializeField] private LevelInfo level4Info;
        
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

        private LevelInfo levelInfo;

        private bool _isPositionBlockRight;
        private bool _isRulesVisible, _isHelpVisible, _isHelpBlockVisible;

        private MeshRenderer _spriteOne, _spriteTwo, _spriteThree, _spriteFour, _spriteFive,
            _spriteHelpOne, _spriteHelpTwo, _spriteHelpThree, _spriteHelpFour, _spriteHelpFive;

        private Color colorOne, colorTwo, colorThree, colorFour, colorFive,
            colorOneHelp, colorTwoHelp, colorThreeHelp, colorFourHelp, colorFiveHelp;

        private float _allowance = 0.3f;
        private float _allowanceLong = 1.5f;
    
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
            if (levelInfo.levelNumber == 1)
            {
                float[] values = DataGame.CheckDistance(levelInfo.levelNumber);
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) > values[0] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockThree.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockThree.transform.position) > values[2] -_allowance)
                {
                    _isPositionBlockRight = true;
                }
            }

            if (levelInfo.levelNumber == 2)
            {
                float[] values = DataGame.CheckDistance(levelInfo.levelNumber);
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) > values[0] - _allowance && 
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[3] + _allowanceLong
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[3] - _allowanceLong &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) < values[4] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) > values[4] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) > values[0] - _allowance && 
                    Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) > values[2] - _allowance&&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[3] + _allowanceLong
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[3] - _allowanceLong &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) < values[4] + _allowance 
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) > values[4] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) > values[0] - _allowance && 
                    Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[5] + _allowanceLong
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[5] - _allowanceLong &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) < values[4] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) > values[4] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) > values[0] - _allowance && 
                    Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFour.transform.position) > values[1] - _allowance&&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[5] + _allowanceLong
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[5] - _allowanceLong &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) < values[4] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) > values[4] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
            }
            
            if (levelInfo.levelNumber == 3)
            {
                float[] values = DataGame.CheckDistance(levelInfo.levelNumber);
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockTwo.transform.position) > values[0] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockOne.transform.position) < values[3] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockOne.transform.position) > values[3] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position) > values[0] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFour.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockOne.transform.position) < values[3] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockOne.transform.position) > values[3] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position) > values[0] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockTwo.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockTwo.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockOne.transform.position) < values[3] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockOne.transform.position) > values[3] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                
                // Debug.Log(Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position));
                // Debug.Log(Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position));
                // Debug.Log(Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockTwo.transform.position));
                // Debug.Log(Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockOne.transform.position));
            }
            
            if (levelInfo.levelNumber == 4)
            {
                float[] values = DataGame.CheckDistance(levelInfo.levelNumber);
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position) > values[0] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFive.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFive.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFive.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFive.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) < values[3] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) > values[3] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                
                if (Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) > values[0] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFive.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFive.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFive.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFive.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) < values[3] + _allowance
                    && Vector3.Distance(levelInfo.blockFour.transform.position, levelInfo.blockFive.transform.position) > values[3] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                
                if (Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockFive.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockFive.transform.position, levelInfo.blockFive.transform.position) > values[0] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFive.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFive.transform.position) > values[1] - _allowance &&
                    Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockThree.transform.position) > values[2] - _allowance &&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[3] + _allowance
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[3] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
                
                if (Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFive.transform.position) < values[0] + _allowance
                    && Vector3.Distance(levelInfo.blockTwo.transform.position, levelInfo.blockFive.transform.position) > values[0] - _allowance&&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFive.transform.position) < values[1] + _allowance
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFive.transform.position) > values[1] - _allowance&&
                    Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position) < values[2] + _allowance
                    && Vector3.Distance(levelInfo.blockOne.transform.position, levelInfo.blockThree.transform.position) > values[2] - _allowance&&
                    Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) < values[3] + _allowance
                    && Vector3.Distance(levelInfo.blockThree.transform.position, levelInfo.blockFour.transform.position) > values[3] - _allowance)
                {
                    _isPositionBlockRight = true;
                }
            }
            return _isPositionBlockRight;
        }
        
        public void CheckButton()
        {
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

        public void SelectLevel1()
        {
            level1Game.SetActive(true);
            levelInfo = level1Info;
            SelectLevel();
        }
        
        public void SelectLevel2()
        {
            level2Game.SetActive(true);
            levelInfo = level2Info;
            SelectLevel();
        }
        
        public void SelectLevel3()
        {
            level3Game.SetActive(true);
            levelInfo = level3Info;
            SelectLevel();
        }
        
        public void SelectLevel4()
        {
            level4Game.SetActive(true);
            levelInfo = level4Info;
            SelectLevel();
        }
        
        private void SelectLevel()
        {
            gamePanel.SetActive(true);
            levelsPanel.SetActive(false);
            rulesPanel.SetActive(false);
            startPanel.SetActive(false);
            
            gameBlock.SetActive(true);
            wrongText.SetActive(false);
            wonText.SetActive(false);
            checkButton.SetActive(true);
            continueButton.SetActive(false);
            
            GetComponent();
            SetColorValue();
            RandomPosition();
            _isPositionBlockRight = false;
            _isHelpVisible = false;
        }

        public void BackButton()
        {
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
            switch (levelInfo.levelNumber)
            {
                case 0:
                default:
                    level1Game.SetActive(true);
                    SelectLevel1();
                    break;
                case 1:
                    level1Game.SetActive(false);
                    level2Game.SetActive(true);
                    SelectLevel2();
                    break;
                case 2:
                    level2Game.SetActive(false);
                    level3Game.SetActive(true);
                    SelectLevel3();
                    break;
                case 3:
                    level3Game.SetActive(false);
                    level4Game.SetActive(true);
                    SelectLevel4();
                    break;
                case 4:
                    level1Game.SetActive(true);
                    level4Game.SetActive(false);
                    SelectLevel1();
                    break;
            }
        }
    
        private void RandomPosition()
        {
            levelInfo.blockOne.transform.rotation = Quaternion.Euler(0, 0, 0);
            levelInfo.blockTwo.transform.rotation = Quaternion.Euler(0, 0, 0);
            levelInfo.blockThree.transform.rotation = Quaternion.Euler(0, 0, 0);
            levelInfo.blockFour.transform.rotation = Quaternion.Euler(0, 0, 0);
            levelInfo.blockFive.transform.rotation = Quaternion.Euler(0, 0, 0);
            
            levelInfo.blockOne.transform.position = new Vector3(Random.Range(-6f, 0f), Random.Range(0f, 8f), 0f);
            levelInfo.blockTwo.transform.position = new Vector3(Random.Range(-6f, 0f), Random.Range(-8f, 0f), 0f);
            levelInfo.blockThree.transform.position = new Vector3(Random.Range(0f, 6f), Random.Range(0f, 8f), 0f);
            levelInfo.blockFour.transform.position = new Vector3(Random.Range(0, 6f), Random.Range(-8f, 0f), 0f);
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
            colorOne.a = 1f;
            colorTwo.a = 1f;
            colorThree.a = 1f;
            colorFour.a = 1f;
            colorFive.a = 1f;
                
            SetColor(_spriteOne, colorOne);
            SetColor(_spriteTwo, colorTwo);
            SetColor(_spriteThree, colorThree);
            SetColor(_spriteFour, colorFour);
            SetColor(_spriteFive, colorFive);
                
            colorOneHelp.a = 0f;
            colorTwoHelp.a = 0f;
            colorThreeHelp.a = 0f;
            colorFourHelp.a = 0f;
            colorFiveHelp.a = 0f;
                
            SetColor(_spriteHelpOne, colorOneHelp);
            SetColor(_spriteHelpTwo, colorTwoHelp);
            SetColor(_spriteHelpThree, colorThreeHelp);
            SetColor(_spriteHelpFour, colorFourHelp);
            SetColor(_spriteHelpFive, colorFiveHelp);
        }

        private static void SetColor(Renderer renderer, Color color)
        {
            renderer.material.color = color;
        }
    }
}
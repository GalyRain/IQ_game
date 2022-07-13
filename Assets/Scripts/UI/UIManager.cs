using System.Collections;
using Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private GameObject level1Game;
        [SerializeField] private GameObject level2Game;
        [SerializeField] private GameObject level3Game;
        [SerializeField] private GameObject level4Game;
        [SerializeField] private GameObject level5Game;
        [SerializeField] private GameObject level6Game;
        [SerializeField] private GameObject level7Game;
        [SerializeField] private GameObject level8Game;
        [SerializeField] private GameObject level9Game;
        [SerializeField] private GameObject level10Game;
        [SerializeField] private GameObject level11Game;
        [SerializeField] private GameObject level12Game;
        [SerializeField] private GameObject level13Game;
        [SerializeField] private GameObject level14Game;
        [SerializeField] private GameObject level15Game;
        [SerializeField] private GameObject level16Game;
        [SerializeField] private GameObject level17Game;
        [SerializeField] private GameObject level18Game;
        [SerializeField] private GameObject level19Game;
        [SerializeField] private GameObject level20Game;
        [SerializeField] private GameObject level21Game;
        
        [Header("Level data info")]
        [SerializeField] private LevelInfo level1Info;
        [SerializeField] private LevelInfo level2Info;
        [SerializeField] private LevelInfo level3Info;
        [SerializeField] private LevelInfo level4Info;
        [SerializeField] private LevelInfo level5Info;
        [SerializeField] private LevelInfo level6Info;
        [SerializeField] private LevelInfo level7Info;
        [SerializeField] private LevelInfo level8Info;
        [SerializeField] private LevelInfo level9Info;
        [SerializeField] private LevelInfo level10Info;
        [SerializeField] private LevelInfo level11Info;
        [SerializeField] private LevelInfo level12Info;
        [SerializeField] private LevelInfo level13Info;
        [SerializeField] private LevelInfo level14Info;
        [SerializeField] private LevelInfo level15Info;
        [SerializeField] private LevelInfo level16Info;
        [SerializeField] private LevelInfo level17Info;
        [SerializeField] private LevelInfo level18Info;
        [SerializeField] private LevelInfo level19Info;
        [SerializeField] private LevelInfo level20Info;
        [SerializeField] private LevelInfo level21Info;
        
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

        private bool _isRulesVisible, _isHelpVisible, _isHelpBlockVisible;

        private MeshRenderer _spriteOne, _spriteTwo, _spriteThree, _spriteFour, _spriteFive,
            _spriteHelpOne, _spriteHelpTwo, _spriteHelpThree, _spriteHelpFour, _spriteHelpFive;

        private Color colorOne, colorTwo, colorThree, colorFour, colorFive,
            colorOneHelp, colorTwoHelp, colorThreeHelp, colorFourHelp, colorFiveHelp;

        private int levelContinue;
        private bool _isLevelContinue = true;

        private void Update()
        {
            if (levelInfo != null && _isLevelContinue && UICheckShapePosition.CheckPosition(levelInfo.levelNumber, levelInfo))
            {
                CheckShape();
                _isLevelContinue = false;
            }
        }

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

        private void CheckShape()
        {
            wrongText.SetActive(false);
            wonText.SetActive(true);
            StartCoroutine(nameof(InVisibleSpriteBlock));
            StartCoroutine(nameof(VisibleSpriteBlockHelper));
            checkButton.SetActive(false);
            continueButton.SetActive(true);
            levelContinue = levelInfo.levelNumber;
            UILevelController.LevelComplete = levelInfo.levelNumber;
            levelInfo.gameBlocks.SetActive(false);
        }

        public void CheckButton()
        {
            if (UICheckShapePosition.CheckPosition(levelInfo.levelNumber, levelInfo))
            {
                CheckShape();
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
        
        public void SelectLevel5()
        {
            level5Game.SetActive(true);
            levelInfo = level5Info;
            SelectLevel();
        }
        
        public void SelectLevel6()
        {
            level6Game.SetActive(true);
            levelInfo = level6Info;
            SelectLevel();
        }
        
        public void SelectLevel7()
        {
            level7Game.SetActive(true);
            levelInfo = level7Info;
            SelectLevel();
        }
        
        public void SelectLevel8()
        {
            level8Game.SetActive(true);
            levelInfo = level8Info;
            SelectLevel();
        }
        
        public void SelectLevel9()
        {
            level9Game.SetActive(true);
            levelInfo = level9Info;
            SelectLevel();
        }
        
        public void SelectLevel10()
        {
            level10Game.SetActive(true);
            levelInfo = level10Info;
            SelectLevel();
        }
        
        public void SelectLevel11()
        {
            level11Game.SetActive(true);
            levelInfo = level11Info;
            SelectLevel();
        }
        
        public void SelectLevel12()
        {
            level12Game.SetActive(true);
            levelInfo = level12Info;
            SelectLevel();
        }
        
        public void SelectLevel13()
        {
            level13Game.SetActive(true);
            levelInfo = level13Info;
            SelectLevel();
        }
        
        public void SelectLevel14()
        {
            level14Game.SetActive(true);
            levelInfo = level14Info;
            SelectLevel();
        }
        
        public void SelectLevel15()
        {
            level15Game.SetActive(true);
            levelInfo = level15Info;
            SelectLevel();
        }
        
        public void SelectLevel16()
        {
            level16Game.SetActive(true);
            levelInfo = level16Info;
            SelectLevel();
        }
        
        public void SelectLevel17()
        {
            level17Game.SetActive(true);
            levelInfo = level17Info;
            SelectLevel();
        }
        
        public void SelectLevel18()
        {
            level18Game.SetActive(true);
            levelInfo = level18Info;
            SelectLevel();
        }
        
        public void SelectLevel19()
        {
            level19Game.SetActive(true);
            levelInfo = level19Info;
            SelectLevel();
        }
        
        public void SelectLevel20()
        {
            level20Game.SetActive(true);
            levelInfo = level20Info;
            SelectLevel();
        }
        
        public void SelectLevel21()
        {
            level21Game.SetActive(true);
            levelInfo = level21Info;
            SelectLevel();
        }

        private void SelectLevel()
        {
            levelInfo.gameBlocks.SetActive(true);
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
            _isHelpVisible = false;
            _isLevelContinue = true;
            UICheckShapePosition.IsPositionBlockRight = false;
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
                        levelInfo.gameBlocks.SetActive(true);
                        _isHelpVisible = false;
                        return;
                    case false:
                        StartCoroutine(nameof(InVisibleSpriteBlock));
                        StartCoroutine(nameof(VisibleSpriteBlockHelper));
                        levelInfo.gameBlocks.SetActive(false);
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
            switch (levelContinue)
            {
                default:
                    SelectLevel1();
                    break;
                case 1:
                    level1Game.SetActive(false);
                    SelectLevel2();
                    break;
                case 2:
                    level2Game.SetActive(false);
                    SelectLevel3();
                    break;
                case 3:
                    level3Game.SetActive(false);
                    SelectLevel4();
                    break;
                case 4:
                    level4Game.SetActive(false);
                    SelectLevel5();
                    break;
                case 5:
                    level5Game.SetActive(false);
                    SelectLevel6();
                    break;
                case 6:
                    level6Game.SetActive(false);
                    SelectLevel7();
                    break;
                case 7:
                    level7Game.SetActive(false);
                    SelectLevel8();
                    break;
                case 8:
                    level8Game.SetActive(false);
                    SelectLevel9();
                    break;
                case 9:
                    level9Game.SetActive(false);
                    SelectLevel10();
                    break;
                case 10:
                    level10Game.SetActive(false);
                    SelectLevel11();
                    break;
                case 11:
                    level11Game.SetActive(false);
                    SelectLevel12();
                    break;
                case 12:
                    level12Game.SetActive(false);
                    SelectLevel13();
                    break;
                case 13:
                    level13Game.SetActive(false);
                    SelectLevel14();
                    break;
                case 14:
                    level14Game.SetActive(false);
                    SelectLevel15();
                    break;
                case 15:
                    level15Game.SetActive(false);
                    SelectLevel16();
                    break;
                case 16:
                    level16Game.SetActive(false);
                    SelectLevel17();
                    break;
                case 17:
                    level17Game.SetActive(false);
                    SelectLevel18();
                    break;
                case 18:
                    level18Game.SetActive(false);
                    SelectLevel19();
                    break;
                case 19:
                    level19Game.SetActive(false);
                    SelectLevel20();
                    break;
                case 20:
                    level20Game.SetActive(false);
                    SelectLevel21();
                    break;
                case 21:
                    level21Game.SetActive(false);
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
            levelInfo.blockFive.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
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
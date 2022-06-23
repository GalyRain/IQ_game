using System.Collections;
using Data;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        private string level = "1";
        [Header("Level elements")]
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
        [Header("Setting")]
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private GameObject rulesPanel;
        [Header("Game")]
        [SerializeField] private GameObject gameBlock;
        [SerializeField] private GameObject rulesText;
        [SerializeField] private GameObject wrongText;
        [SerializeField] private GameObject wonText;

        private bool _isOneTwo, _isOneThree, _isOneFour, _isTwoThree, _isTwoFour, _isThreeFour, _isRight;
        private bool _isRulesVisible, _isHelpVisible, _isHelpBlockVisible;

        private MeshRenderer _spriteOne, _spriteTwo, _spriteThree, _spriteFour, _spriteHelpOne, _spriteHelpTwo,
            _spriteHelpThree, _spriteHelpFour;

        private Color colorOne, colorTwo, colorThree, colorFour, colorOneHelp, colorTwoHelp, colorThreeHelp, colorFourHelp;
    
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
            
            colorOneHelp = _spriteHelpOne.material.color;
            colorTwoHelp = _spriteHelpTwo.material.color;
            colorThreeHelp = _spriteHelpThree.material.color;
            colorFourHelp = _spriteHelpFour.material.color;
            
            colorOne = _spriteOne.material.color;
            colorTwo = _spriteTwo.material.color;
            colorThree = _spriteThree.material.color;
            colorFour = _spriteFour.material.color;
        }
        
        private bool CheckPosition()
        {
            float[] values = DataGame.CheckDistance(level);
            if (Vector3.Distance(blockOne.transform.position, blockTwo.transform.position) < values[0]
                && Vector3.Distance(blockOne.transform.position, blockTwo.transform.position) > values[1])
            {
                _isOneTwo = true;
            }
        
            if (Vector3.Distance(blockOne.transform.position, blockThree.transform.position) < values[2]
                && Vector3.Distance(blockOne.transform.position, blockThree.transform.position) > values[3])
            {
                _isOneThree = true;
            }
            if (Vector3.Distance(blockOne.transform.position, blockFour.transform.position) < values[4]
                && Vector3.Distance(blockOne.transform.position, blockFour.transform.position) > values[5])
            {
                _isOneFour = true;
            }
            if (Vector3.Distance(blockTwo.transform.position, blockThree.transform.position) < values[6]
                && Vector3.Distance(blockTwo.transform.position, blockThree.transform.position) > values[7])
            {
                _isTwoThree = true;
            }
            if (Vector3.Distance(blockTwo.transform.position, blockFour.transform.position) < values[8]
                && Vector3.Distance(blockTwo.transform.position, blockFour.transform.position) > values[9])
            {
                _isTwoFour = true;
            }
            if (Vector3.Distance(blockThree.transform.position, blockFour.transform.position) < values[10]
                && Vector3.Distance(blockThree.transform.position, blockFour.transform.position) > values[11])
            {
                _isThreeFour = true;
            }

            if (_isOneTwo && _isOneThree && _isOneFour && _isTwoThree && _isTwoFour && _isThreeFour)
            {
                _isRight = true;
            }
            return _isRight;
        }

        public void CheckButton()
        {
            // Debug.Log(Vector3.Distance(blockOne.transform.position, blockTwo.transform.position));
            // Debug.Log(Vector3.Distance(blockOne.transform.position, blockThree.transform.position));
            // Debug.Log(Vector3.Distance(blockOne.transform.position, blockFour.transform.position));
            // Debug.Log(Vector3.Distance(blockTwo.transform.position, blockThree.transform.position));
            // Debug.Log(Vector3.Distance(blockTwo.transform.position, blockFour.transform.position));
            // Debug.Log(Vector3.Distance(blockThree.transform.position, blockFour.transform.position));
            // Debug.Log(CheckPosition());
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
            gamePanel.SetActive(true);
            
            gameBlock.SetActive(true);
            wrongText.SetActive(false);
            wonText.SetActive(false);
            
            RandomPosition();
            CheckFalse();
            _isHelpVisible = false;
        }
        
        public void BackButton()
        {
            SetColorValue();
            startPanel.SetActive(true);
            gamePanel.SetActive(false);
            rulesPanel.SetActive(false);
            
            gameBlock.SetActive(false);
            helperModel.SetActive(false);
            
            wrongText.SetActive(false);
            rulesText.SetActive(false);
            
            _isRulesVisible = false;
            _isHelpVisible = false;
            _isHelpBlockVisible = false;
        }
        
        public void RulesButton()
        {
            startPanel.SetActive(false);
            rulesPanel.SetActive(true);
        }
        
        public void GameRulesButton()
        {
            switch (_isRulesVisible)
            {
                case false:
                    rulesText.SetActive(true);
                    gameBlock.SetActive(false);
                    helperBlock.SetActive(false);
                    break;
                case true:
                    rulesText.SetActive(false);
                    gameBlock.SetActive(true);
                    helperBlock.SetActive(true);
                    break;
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
            for (float f = 1f; f <= 1; f += 0.1f)
            {
                colorOne = _spriteOne.material.color;
                colorTwo = _spriteTwo.material.color;
                colorThree = _spriteThree.material.color;
                colorFour = _spriteFour.material.color;
                
                colorOne.a = f;
                colorTwo.a = f;
                colorThree.a = f;
                colorFour.a = f;
                
                SetColor(_spriteOne, colorOne);
                SetColor(_spriteTwo, colorTwo);
                SetColor(_spriteThree, colorThree);
                SetColor(_spriteFour, colorFour);
                
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
                
                colorOne.a = f;
                colorTwo.a = f;
                colorThree.a = f;
                colorFour.a = f;
                
                SetColor(_spriteOne, colorOne);
                SetColor(_spriteTwo, colorTwo);
                SetColor(_spriteThree, colorThree);
                SetColor(_spriteFour, colorFour);
                
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
                
                colorOneHelp.a = f;
                colorTwoHelp.a = f;
                colorThreeHelp.a = f;
                colorFourHelp.a = f;
                
                SetColor(_spriteHelpOne, colorOneHelp);
                SetColor(_spriteHelpTwo, colorTwoHelp);
                SetColor(_spriteHelpThree, colorThreeHelp);
                SetColor(_spriteHelpFour, colorFourHelp);
                
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
                
                colorOneHelp.a = f;
                colorTwoHelp.a = f;
                colorThreeHelp.a = f;
                colorFourHelp.a = f;
                
                SetColor(_spriteHelpOne, colorOneHelp);
                SetColor(_spriteHelpTwo, colorTwoHelp);
                SetColor(_spriteHelpThree, colorThreeHelp);
                SetColor(_spriteHelpFour, colorFourHelp);
                
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void SetColorValue()
        {
            colorOneHelp.a = 0;
            colorTwoHelp.a = 0;
            colorThreeHelp.a = 0;
            colorFourHelp.a = 0;
            
            colorOne.a = 1;
            colorTwo.a = 1;
            colorThree.a = 1;
            colorFour.a = 1;

            SetColor(_spriteHelpOne, colorOneHelp);
            SetColor(_spriteHelpTwo, colorTwoHelp);
            SetColor(_spriteHelpThree, colorThreeHelp);
            SetColor(_spriteHelpFour, colorFourHelp);

            SetColor(_spriteOne, colorOne);
            SetColor(_spriteTwo, colorTwo);
            SetColor(_spriteThree, colorThree);
            SetColor(_spriteFour, colorFour);
        }

        private static void SetColor(Renderer renderer, Color color)
        {
            renderer.material.color = color;
        }
    }
}
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILevelController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button level1Button;
        [SerializeField] private Button level2Button;
        [SerializeField] private Button level3Button;
        [SerializeField] private Button level4Button;
        [SerializeField] private Button level5Button;
        [SerializeField] private Button level6Button;
        [SerializeField] private Button level7Button;
        [SerializeField] private Button level8Button;
        [SerializeField] private Button level9Button;
        [SerializeField] private Button level10Button;
        [SerializeField] private Button level11Button;
        [SerializeField] private Button level12Button;
        [SerializeField] private Button level13Button;
        [SerializeField] private Button level14Button;
        [SerializeField] private Button level15Button;
        [SerializeField] private Button level16Button;
        [SerializeField] private Button level17Button;
        [SerializeField] private Button level18Button;
        [SerializeField] private Button level19Button;
        [SerializeField] private Button level20Button;
        [SerializeField] private Button level21Button;
        
        public static int LevelComplete;
        public bool level1;
        public bool level2;
        public bool level3;
        public bool level4;
        public bool level5;
        public bool level6;
        public bool level7;
        public bool level8;
        public bool level9;
        public bool level10;
        public bool level11;
        public bool level12;
        public bool level13;
        public bool level14;
        public bool level15;
        public bool level16;
        public bool level17;
        public bool level18;
        public bool level19;
        public bool level20;
        public bool level21;
        
        private void Start()
        {
            LoadLevel();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SaveLevel();
                Debug.Log("Save");
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadLevel();
                Debug.Log("Load");
            }

            SetLevelComplete();
            SetButtonColor();
        }

        private void SetLevelComplete()
        {
            switch (LevelComplete)
            {
                case 1:
                    level1 = true;
                    SaveLevel();
                    break;
                case 2:
                    level2 = true;
                    SaveLevel();
                    break;
                case 3:
                    level3 = true;
                    SaveLevel();
                    break;
                case 4:
                    level4 = true;
                    SaveLevel();
                    break;
                case 5:
                    level5 = true;
                    SaveLevel();
                    break;
                case 6:
                    level6 = true;
                    SaveLevel();
                    break;
                case 7:
                    level7 = true;
                    SaveLevel();
                    break;
                case 8:
                    level8 = true;
                    SaveLevel();
                    break;
                case 9:
                    level9 = true;
                    SaveLevel();
                    break;
                case 10:
                    level10 = true;
                    SaveLevel();
                    break;
                case 11:
                    level11 = true;
                    SaveLevel();
                    break;
                case 12:
                    level12 = true;
                    SaveLevel();
                    break;
                case 13:
                    level13 = true;
                    SaveLevel();
                    break;
                case 14:
                    level14 = true;
                    SaveLevel();
                    break;
                case 15:
                    level15 = true;
                    SaveLevel();
                    break;
                case 16:
                    level16 = true;
                    SaveLevel();
                    break;
                case 17:
                    level17 = true;
                    SaveLevel();
                    break;
                case 18:
                    level18 = true;
                    SaveLevel();
                    break;
                case 19:
                    level19 = true;
                    SaveLevel();
                    break;
                case 20:
                    level20 = true;
                    SaveLevel();
                    break;
                case 21:
                    level21 = true;
                    SaveLevel();
                    break;
            }
        }

        private void SetButtonColor()
        {
            level1Button.GetComponent<Image>().color = level1 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level2Button.GetComponent<Image>().color = level2 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level3Button.GetComponent<Image>().color = level3 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level4Button.GetComponent<Image>().color = level4 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level5Button.GetComponent<Image>().color = level5 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level6Button.GetComponent<Image>().color = level6 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level7Button.GetComponent<Image>().color = level7 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level8Button.GetComponent<Image>().color = level8 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level9Button.GetComponent<Image>().color = level9 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level10Button.GetComponent<Image>().color = level10 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level11Button.GetComponent<Image>().color = level11 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level12Button.GetComponent<Image>().color = level12 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level13Button.GetComponent<Image>().color = level13 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level14Button.GetComponent<Image>().color = level14 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level15Button.GetComponent<Image>().color = level15 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level16Button.GetComponent<Image>().color = level16 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level17Button.GetComponent<Image>().color = level17 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level17Button.GetComponent<Image>().color = level17 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level18Button.GetComponent<Image>().color = level18 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level19Button.GetComponent<Image>().color = level19 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level20Button.GetComponent<Image>().color = level20 switch
            {
                true => Color.gray,
                false => Color.white
            };
            level21Button.GetComponent<Image>().color = level21 switch
            {
                true => Color.gray,
                false => Color.white
            };
        }

        private void SaveLevel()
        {
            SaveSystem.SaveLevel(this);
        }

        private void LoadLevel()
        {
            LevelData data = SaveSystem.LoadLevel();
            
            level1 = data.level1;
            level2 = data.level2;
            level3 = data.level3;
            level4 = data.level4;
            level5 = data.level5;
            level6 = data.level6;
            level7 = data.level7;
            level8 = data.level8;
            level9 = data.level9;
            level10 = data.level10;
            level11 = data.level11;
            level12 = data.level12;
            level13 = data.level13;
            level14 = data.level14;
            level15 = data.level15;
            level16 = data.level16;
            level17 = data.level17;
            level18 = data.level18;
            level19 = data.level19;
            level20 = data.level20;
            level21 = data.level21;
        }

        public void ResetProgress()
        {
            LevelComplete = 0;
            
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            level6 = false;
            level7 = false;
            level8 = false;
            level9 = false;
            level10 = false;
            level11 = false;
            level12 = false;
            level13 = false;
            level14 = false;
            level15 = false;
            level16 = false;
            level17 = false;
            level18 = false;
            level19 = false;
            level20 = false;
            level21 = false;
            SetButtonColor();
        }
    }
}
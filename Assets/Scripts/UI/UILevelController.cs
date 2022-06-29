using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILevelController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button levelTwoButton;
        [SerializeField] private Button levelThreeButton;
        
        public static int LevelComplete;
        private UIManager _uiManager;

        private void Start()
        {
            LevelComplete = PlayerPrefs.GetInt(nameof(LevelComplete));
            levelTwoButton.interactable = false;
            levelThreeButton.interactable = false;
        }

        private void Update()
        {
            switch (LevelComplete)
            {
                case 1:
                    levelTwoButton.interactable = true;
                    break;
                case 2:
                    levelTwoButton.interactable = true;
                    levelThreeButton.interactable = true;
                    break;
            }
        }

        public void ResetLevelsButton()
        {
            levelTwoButton.interactable = false;
            levelThreeButton.interactable = false;
            LevelComplete = 0;
            PlayerPrefs.DeleteAll();
        }
    }
}

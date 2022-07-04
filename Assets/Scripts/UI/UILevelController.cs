using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILevelController : MonoBehaviour
    {
        [Header("Buttons")]
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
        private UIManager _uiManager;

        private void Start()
        {
            LevelComplete = PlayerPrefs.GetInt(nameof(LevelComplete));
            // level2Button.interactable = false;
        }

        private void SetLevelComplete()
        {
            switch (LevelComplete)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                case 21:
                    break;
            }
        }

        public void ResetLevelsButton()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace UI
{
    public class UISetLocalization : MonoBehaviour
    {
        private void SetSelectLocale(Locale locale)
        {
            LocalizationSettings.SelectedLocale = locale;
        }

        public void EnglishButton()
        {
            SetSelectLocale(LocalizationSettings.AvailableLocales.Locales[0]);
        }
        
        public void RussianButton()
        {
            SetSelectLocale(LocalizationSettings.AvailableLocales.Locales[1]);
        }
    }
}
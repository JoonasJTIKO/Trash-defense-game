using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace towerdefense
{
    public class SelectLanguage : MonoBehaviour
    {
        [SerializeField] 
        private Locale language;

		public void SetLanguage()
		{
			LocalizationSettings.SelectedLocale = language;
		}
    }
}

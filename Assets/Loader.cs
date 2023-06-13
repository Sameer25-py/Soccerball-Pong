using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Loader : MonoBehaviour
    {
        public Image    LoaderFill;
        public TMP_Text LoaderText;

        private IEnumerator ProgressLoader()
        {
            float elapsedTime = 0f;
            while (elapsedTime < 1f)
            {
                elapsedTime           += Time.deltaTime / 2f;
                LoaderFill.fillAmount =  elapsedTime;
                LoaderText.text       =  ((int)(elapsedTime * 100f)) + "%";
                yield return null;
            }

            SceneManager.LoadScene("Gameplay");
        }

        private void Start()
        {
            StartCoroutine(ProgressLoader());
        }
    }
}
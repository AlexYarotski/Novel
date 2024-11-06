using System.Collections;
using Naninovel.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Dev.Scripts
{
    public class FindPairGameUI : CustomUI
    {
        public void Enable()
        {
            gameObject.SetActive(true);
            
            var findPair = GetComponent<FindPairGame>();
            findPair.Reset();
            
            Image[] images = GetComponentsInChildren<Image>(true);

            foreach (var image in images)
            {
                image.gameObject.SetActive(true);
                
                var color = image.color;
                color.a = 1f;
                image.color = color;
            }
        }

        public void FadeOutAllElements(float duration = 1f)
        {
            Image[] images = GetComponentsInChildren<Image>(true);
            StartCoroutine(FadeOutCoroutine(images, duration));
        }

        private IEnumerator FadeOutCoroutine(Image[] images, float duration)
        {
            float timeElapsed = 0f;

            while (timeElapsed < duration)
            {
                foreach (var image in images)
                {
                    var color = image.color;
                    color.a = Mathf.Lerp(1f, 0f, timeElapsed / duration);
                    image.color = color;
                }

                timeElapsed += Time.deltaTime;
                yield return null;
            }

            foreach (var image in images)
            {
                var color = image.color;
                color.a = 0f;
                image.color = color;
                image.gameObject.SetActive(false);
            }
        }
    }
}
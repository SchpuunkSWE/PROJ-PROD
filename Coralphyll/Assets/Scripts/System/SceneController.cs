using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad; //Decide for yourself which scene to load in the inspector

    //[SerializeField]
    //private Image fadeImage;

    //private float alpha;

    private void Start()
    {
        //sceneToload = SceneManager.GetActiveScene().buildIndex + 1; //Switches to the scene after the current one
        //StartCoroutine(FadeIn());
    }
    //private IEnumerator FadeIn()
    //{
    //    alpha = 1;

    //    while (alpha > 0)
    //    {
    //        alpha -= Time.deltaTime;
    //        fadeImage.color = new Color(0, 0, 0, alpha);
    //        yield return new WaitForSeconds(0);
    //    }
    //    fadeImage.gameObject.SetActive(false);
    //}
    private void OnTriggerEnter(Collider other)
    {
        //fadeImage.gameObject.SetActive(true);
        if (other.CompareTag("Player"))
        {
            //StartCoroutine(FadeOut());
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    //private IEnumerator FadeOut()
    //{
    //    alpha = 0;

    //    while (alpha < 1)
    //    {
    //        alpha += Time.deltaTime;
    //        fadeImage.color = new Color(0, 0, 0, alpha);
    //        yield return new WaitForSeconds(0);
    //    }

    //    SceneManager.LoadScene(sceneToLoad);
    //}
}

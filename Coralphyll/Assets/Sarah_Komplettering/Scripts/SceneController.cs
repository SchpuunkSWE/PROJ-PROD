using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad; //Decide for yourself which scene to load in the inspector

    [SerializeField]
    private ParticleSystem openedParticles; //Bara ngt för att visa att den finns när den aktiveras 

    [SerializeField]
    private Animator transition; //Reference to animator. Populate in inspector.

    [SerializeField]
    private float transitionTime = 1f;

    public ParticleSystem GetParticles()
    {
        return openedParticles;
    }
    private void Start()
    {
        //sceneToload = SceneManager.GetActiveScene().buildIndex + 1; //Switches to the scene after the current one
        //StartCoroutine(FadeIn());
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel());
            Debug.Log("Corutine started");
            Logger.LoggerInstance.CreateTextFile("Level " + sceneToLoad + ":");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Logger.LoggerInstance.CreateTextFile("Level " + sceneToLoad + ":");
    }

    private IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start"); //Play animation.

        yield return new WaitForSeconds(transitionTime); //Wait for x amount of seconds.
        
        SceneManager.LoadScene(sceneToLoad);
    }
}

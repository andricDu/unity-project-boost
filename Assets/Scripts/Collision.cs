using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (!isTransitioning) {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Friendly!");
                    break;
                case "Finish":
                    StartSuccessSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        crashParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        successParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(finish);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int next = current + 1;
        if (next == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        } else
        {
            SceneManager.LoadScene(next);
        }
    }
}

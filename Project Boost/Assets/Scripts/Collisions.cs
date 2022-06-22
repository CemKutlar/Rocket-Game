using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticles;

    bool isASequenceTriggered;
    bool isCollisionCheatActive = false;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (isCollisionCheatActive) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Slapper":
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartSuccessSequence()
    {
        
        if (isASequenceTriggered != true)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(successSound);
            successParticles.Play();
        }

        isASequenceTriggered = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        
        if (isASequenceTriggered != true)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(deathSound);
            deathParticles.Play();
        }

        isASequenceTriggered = true;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        GetComponent<Movement>().enabled = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        GetComponent<Movement>().enabled = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public bool GetIsCollisionCheatActive()
    {
        return isCollisionCheatActive;
    }

    public void SetIsCollisionCheatActive(bool b)
    {
        isCollisionCheatActive = b;
    }
}

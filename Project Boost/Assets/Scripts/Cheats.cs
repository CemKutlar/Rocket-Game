using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    Collisions collisions;
    // Start is called before the first frame update
    void Start()
    {
        collisions = GetComponent<Collisions>();
    }

    // Update is called once per frame
    void Update()
    {
        RunCheats();
    }

    void RunCheats()
    {
        LoadNextLevelCheat();
        DeactivteCollision();
    }

    void LoadNextLevelCheat()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    void DeactivteCollision()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisions.SetIsCollisionCheatActive(!collisions.GetIsCollisionCheatActive());
        }
        
    }
}

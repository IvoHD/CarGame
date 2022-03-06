using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] ParticleSystem WinEffect;
    [SerializeField] Scene Scene;


    // Update is called once per frame
    void Update()
    {
        hasWon();
    }

    void hasWon()
    {
        if (GameObject.FindGameObjectsWithTag("Package").Length == 0 && !GetComponent<Collision>().hasPackage) {
            WinEffect.Play();
            Invoke("ReloadScene", 3f);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

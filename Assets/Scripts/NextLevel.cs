using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Scene scene;



    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("finish"); 
        }
  
    }



    public void StartLEvel()
    {
        SceneManager.LoadScene(scene.buildIndex + 1 );
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
  
    private AudioSource audio;
    [SerializeField] private TextMeshProUGUI text;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        text.text = Score.totalScore.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Elmas"))
        {
            audio.Play();
            Destroy(collision.gameObject);
            Score.totalScore++;
            text.text = Score.totalScore.ToString();
        }
    }
}

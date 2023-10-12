using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SetMusicState : MonoBehaviour
{
    static float FADE_TIME_SECONDS = 10;
    float musicVolime = 0.03f;
    Coroutine Stop_FadeIn;

    public AudioSource music;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            music.Play();
            Stop_FadeIn = StartCoroutine(FadeIn());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(Stop_FadeIn);
            StartCoroutine(FadeOut());
                //music.Stop();
        }
    }

    IEnumerator FadeIn()
    {
        float timeElapsed = 0;

        while (music.volume < musicVolime)
        {
            music.volume = Mathf.Lerp(0, musicVolime, timeElapsed / FADE_TIME_SECONDS);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }

    IEnumerator FadeOut()
    {
        float timeElapsed = 0;

        while (music.volume > 0)
        {
            music.volume = Mathf.Lerp(music.volume, 0, timeElapsed / FADE_TIME_SECONDS);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

}

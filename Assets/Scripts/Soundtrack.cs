using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soundtrack : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip startSoundClip;
    public AudioClip crimeSceneClip;
    public AudioClip interrogationClip;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource.clip = startSoundClip;
        myAudioSource.Play();
        StartCoroutine(LoadSceneAfterSound("Interrogation"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadSceneAfterSound(string sceneName)
    {
        // Wait for the audio to finish playing
        yield return new WaitForSeconds(startSoundClip.length);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}

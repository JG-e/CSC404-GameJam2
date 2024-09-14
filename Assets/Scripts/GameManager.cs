using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set;}

    private Scenes currScene;

    private bool switchingScenes = false;

    private enum Scenes{
        CrimeScene,
        InterrogationScene,
        StartScene,
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currScene = Scenes.StartScene;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSceneTest(){
        if(switchingScenes){
            return;
        }
        switchingScenes = true;
        StartCoroutine(LoadSceneAsync("Assets/Scenes/Test Scene2.unity"));
    }

    IEnumerator LoadSceneAsync(string sceneName){
        yield return new WaitForSeconds(0.2f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while(!asyncLoad.isDone){
            yield return null;
        }
    }
}

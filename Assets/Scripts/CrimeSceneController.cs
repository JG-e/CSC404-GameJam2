using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimeSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    private float currentTime;
    [SerializeField]
    private float timeInCrimeScene = 120.0f;
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime + " " + timeInCrimeScene);
        if(currentTime >= timeInCrimeScene){
            gameManager.ChangeSceneTest();
            //SceneManager.LoadScene("Assets/Scenes/Test Scene2.unity");
        }
    }
}

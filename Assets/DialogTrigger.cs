using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    private int i = 0;

    public void StartDialogue()
    {
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
    }

    private void Update()
    {
        if (i == 0)
        {
            StartDialogue();
            i++;
        }
    }
}

[System.Serializable]
public class Message
{
    public int actorid;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}



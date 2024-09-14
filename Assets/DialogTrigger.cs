using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDialogue();
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



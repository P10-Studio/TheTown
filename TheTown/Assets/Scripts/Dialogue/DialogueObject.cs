using UnityEngine;

[System.Serializable]
public class Replique
{
    public string text;
    public string speaker;
    public Sprite portrait;
    public AudioClip audioClip;
}

[CreateAssetMenu(fileName = "DialogueObject", menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    public string Name;
    public string Description;
    public Replique[] Replies;
    public DialogueCondition Condition;
}

public enum DialogueCondition
{
    None,
    QuestCompleted,
}
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues/New Dialogue")]
public class DialogueSO : ScriptableObject
{
    public string title;
    public string description;
    public SubdialogueSO[] dialogues;
}

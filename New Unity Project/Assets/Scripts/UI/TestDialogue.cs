using UnityEngine;
using System.Collections;
public class TestDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager DM;
    bool started = false;
    private void Start()
    {
        DM = FindObjectOfType<DialogueManager>();
        StartCoroutine(StartDialogue());
        
    }
    IEnumerator StartDialogue() {
        yield return new WaitForSeconds(5.0f);
        DM.ShowDialogue(dialogue);
    }

}

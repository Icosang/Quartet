using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager DM;
    private void Start()
    {
        DM = FindObjectOfType<DialogueManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            DM.ShowDialogue(dialogue);
        }
    }
}

using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager DM;
    bool started = false;
    private void Start()
    {
        DM = FindObjectOfType<DialogueManager>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X) && !started) {
            DM.ShowDialogue(dialogue);
            started = true;
        }
    }
}

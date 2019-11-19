using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UB.Simple2dWeatherEffects.Standard;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;

    #region Singleton
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }
    #endregion Singleton

    public Text text;
    public SpriteRenderer rendererSprite; //스탠딩일러스트
    public SpriteRenderer rendererSprite2; //스탠딩일러스트2
    public SpriteRenderer rendererDialogueWindow; //대화상자

    private List<string> listSentences;
    private List<Sprite> listSprites;
    private List<Sprite> listSprites2;
    private List<Sprite> listDialogueWindows;

    private int count; // 대화 진행 상황 카운트.

    public Animator animSprite;
    public Animator animSprite2;
    //public Animator animDialogueWindow;

    public bool talking = false;
    private bool keyActivated = false;
    bool ontalk = false;
    float talkdelay = 0.05f;
    GameManager manager;
    [SerializeField]
    Dialogue dialogue;
    SoundManager soundManager;

    // Use this for initialization
    void OnEnable()
    {
        count = 0;
        text.text = "";
        listSentences = new List<string>();
        listSprites = new List<Sprite>();
        listSprites2 = new List<Sprite>();
        listDialogueWindows = new List<Sprite>();
        manager = D.Get<GameManager>();
        ShowDialogue(dialogue);
        soundManager = D.Get<SoundManager>();
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        talking = true;

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            listSentences.Add(dialogue.sentences[i]);
            listSprites.Add(dialogue.sprites[i]);
            listSprites2.Add(dialogue.sprites2[i]);
            listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }
        //animDialogueWindow.SetBool("Appear", true);
        rendererDialogueWindow.enabled = true;
        StartCoroutine(StartDialogueCoroutine());
    }
    public void ExitDialogue()
    {
        text.text = "";
        count = 0;
        listSentences.Clear();
        listSprites.Clear();
        listDialogueWindows.Clear();
        animSprite.SetBool("Appear", false);
        animSprite2.SetBool("Appear", false);
        rendererDialogueWindow.enabled = false;
        //animDialogueWindow.SetBool("Appear", false);
        talking = false;
        StartCoroutine(WaitandRelease());
    }
    IEnumerator WaitandRelease() {
        yield return new WaitForSeconds(1.0f);
        //GMloader에서 걸었던 것 해제
        manager.isindialogue = false;
        manager.ispausing = false;
        Camera.main.GetComponent<D2FogsNoiseTexPE>().VerticalSpeed = 0.2f;
        if (manager.cleared) {
            soundManager.sounds["Bunnyhop"].Stop();
            manager.Fade();
            yield return new WaitForSeconds(1.5f);
            
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator StartDialogueCoroutine()
    {
        if (count > 0)
        {
                yield return new WaitForSeconds(0.2f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
                if (listSprites[count] != listSprites[count - 1])
                {
                    if(listSprites[count - 1] == null) animSprite.SetBool("Appear", true);
                    yield return new WaitForSeconds(0.1f);
                    rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
                }
                if (listSprites2[count] != listSprites2[count - 1])
                {
                    if (listSprites2[count - 1] == null) animSprite2.SetBool("Appear", true);
                    yield return new WaitForSeconds(0.1f);
                    rendererSprite2.GetComponent<SpriteRenderer>().sprite = listSprites2[count];
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }

        }
        else if (count == 0)
        {
            yield return new WaitForSeconds(0.05f);
            rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
            rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
            rendererSprite2.GetComponent<SpriteRenderer>().sprite = listSprites2[count];
            if (listSprites[count] != null) {
                animSprite.SetBool("Appear", true);
            }
            if (listSprites2[count] != null)
            {
                animSprite2.SetBool("Appear", true);
            }
        }
        keyActivated = true;
        ontalk = true;

        for (int i = 0; i < listSentences[count].Length; i++)
        {
            text.text += listSentences[count][i]; // 1글자씩 출력.
            if (ontalk) yield return new WaitForSeconds(talkdelay);
        }
        ontalk = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (talking && keyActivated)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (ontalk) {
                    // 말하는도중이면 대사를 끝까지 출력
                    ontalk = false;
                    return;
                }
                keyActivated = false;
                count++;
                text.text = "";

                if (count == listSentences.Count)
                {
                    StopAllCoroutines();
                    ExitDialogue();
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());
                }
            }
        }
    }
}
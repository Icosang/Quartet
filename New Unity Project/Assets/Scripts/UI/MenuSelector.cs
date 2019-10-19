using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    [SerializeField]
    private int menulength = 4;
    int index = 0;
    float delayTimer = 0;
    float delayTime = 0.2f;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        D.Get<SoundManager>().sounds["1635"].Play();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && (delayTimer <= 0))
        {
            index++;
            delayTimer = delayTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && (delayTimer <= 0))
        {
            index--;
            delayTimer = delayTime;
        }

        if (index < 0) index = menulength - 1;

        if (index == menulength) index = 0;

        animator.SetInteger("Index", index);

        if (delayTimer > 0) delayTimer -= Time.deltaTime;
        //Z누를시 작동
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
        {
            switch (index) {
                case 0:
                    SceneManager.LoadScene("DrumScene");
                    D.Get<SoundManager>().sounds["1635"].Stop();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }

    }
}

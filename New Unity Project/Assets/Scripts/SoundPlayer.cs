using System.Collections;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    SoundManager soundManager;
    [SerializeField]
    string index = null;
    void Start()
    {
        soundManager = D.Get<SoundManager>();   
    }

    public void PlaySound() {
        soundManager.sounds[index].Play();
    }
}

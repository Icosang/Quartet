using UnityEngine;
using UnityEngine.UI;

public class LifeImage : MonoBehaviour
{
    [SerializeField]
    Image[] lifes = null;
    GameManager manager;

    private void Start()
    {
        manager = D.Get<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (manager.life)
        {
            case 1:
                lifes[1].color = new Color(0, 0, 0, 0);
                lifes[0].color = new Color(0, 0, 0, 1);
                break;
            case 2:
                lifes[2].color = new Color(0, 0, 0, 0);
                lifes[1].color = new Color(0, 0, 0, 1);
                break;
            case 3:
                lifes[3].color = new Color(0, 0, 0, 0);
                lifes[2].color = new Color(0,0,0, 1);
                break;
            case 4:
                break;
        }
    }
}


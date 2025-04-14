using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image[] hearts;

    public void SetHealth(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemUI : MonoBehaviour
{
    public Sprite blackSprite, coloredSprite;

    private Image image;

    public bool active;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void ChangeSprite()
    {
        if (active)
        {
            image.sprite = coloredSprite;
        }
        else
        {
            image.sprite = blackSprite;
        }
    }
}

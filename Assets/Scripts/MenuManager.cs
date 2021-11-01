using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<MenuItemUI> menuItems = new List<MenuItemUI>();

    public void MakeAllColored()
    {
        foreach (MenuItemUI item in menuItems)
        {
            item.active = false;
            item.ChangeSprite();
        }
    }

    public void ChangeItemColor(int itemNumber)
    {
        OffButtens();
        menuItems[itemNumber].active = !menuItems[itemNumber].active;

        menuItems[itemNumber].ChangeSprite();
    }
    public void OffButtens()
    {
        foreach (MenuItemUI item in menuItems)
        {
            item.active = false;
            item.ChangeSprite();
        }
    }
}

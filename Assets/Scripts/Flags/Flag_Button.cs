using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Flag_Button : MonoBehaviour
{

    public Countries Countries_script;
    public string FlagTag;
    public void SetFlag()
    {
        Countries_script.SetFalgByTag(FlagTag);
    }

public void Init(Action onLanguageChoosed)
{

}
}
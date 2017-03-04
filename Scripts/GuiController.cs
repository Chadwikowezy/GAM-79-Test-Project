//This system is highly experimental and subject to change
//as the project matures, hence all the comments.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public delegate void baseStat();
    public event baseStat StatBarUpdates;

    public void UpdateStatBars()
    {
        StatBarUpdates();
    }
}

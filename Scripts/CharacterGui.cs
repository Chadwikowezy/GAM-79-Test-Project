﻿//This system is highly experimental and subject to change
//as the project matures, hence all the comments.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGui : MonoBehaviour
{
    //TestBaseCharacter needs to be replaced by the final
    //base character script.
    private TestBaseCharacter _bc;

    private GuiController _gc;

    [SerializeField]
    private Image _healthBar;

    void Start()
    {
        _bc = GetComponentInParent<TestBaseCharacter>();
        _gc = FindObjectOfType<GuiController>();
        _gc.StatBarUpdates += SetHealthBar;
    }

    void SetHealthBar()
    {
        //Opted for this instead of passing int into the event as a parameter.
        //This is because if we give the event a value, it will change the health
        //bar for all of the characters by that same amount. That is not what we want.
        float health = _bc.GetHealth();
        float maxHealth = _bc.GetMaxHealth();
        float newSize = health / maxHealth;

        StartCoroutine(LerpHealthBar(newSize));
    }

    IEnumerator LerpHealthBar(float targetSize)
    {
        float lerpSpeed = 0.1f;
        float currentSize = _healthBar.rectTransform.localScale.x;
        float newSize;

        while (currentSize != targetSize)
        {
            newSize = Mathf.Lerp(currentSize, targetSize, lerpSpeed);
            _healthBar.rectTransform.localScale = new Vector3(newSize, _healthBar.rectTransform.localScale.y);
            lerpSpeed += 0.2f;
            yield return new WaitForEndOfFrame();
        }
    }
}

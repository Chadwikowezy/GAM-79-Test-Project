//This system is highly experimental and subject to change
//as the project matures, hence all the comments.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGui : MonoBehaviour
{
    //TestBaseCharacter needs to be replaced by the final
    //base character script.
    private TestBaseCharacter bc;

    private GuiController gc;

    [SerializeField]
    private Image healthBar;

    void Awake()
    {
        bc = GetComponent<TestBaseCharacter>();
        gc = FindObjectOfType<GuiController>();
        gc.StatBarUpdates += SetHealthBar;
    }

    void SetHealthBar()
    {
        //Opted for this instead of passing int into the event as a parameter.
        //This is because if we give the event a value, it will change the health
        //bar for all of the characters by that same amount. That is not what we want.
        float newSize = bc.GetHealth() * 0.01f;

        StartCoroutine(LerpHealthBar(newSize));
    }

    IEnumerator LerpHealthBar(float targetSize)
    {
        float lerpSpeed = 0.1f;
        float currentSize = healthBar.rectTransform.localScale.x;
        float newSize;

        while (currentSize != targetSize)
        {
            newSize = Mathf.Lerp(currentSize, targetSize, lerpSpeed);
            healthBar.rectTransform.localScale = new Vector3(newSize, healthBar.rectTransform.localScale.y);
            lerpSpeed += 0.2f;
            yield return new WaitForEndOfFrame();
        }
    }
}

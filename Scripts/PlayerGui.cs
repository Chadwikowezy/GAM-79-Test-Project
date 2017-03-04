//This system is highly experimental and subject to change
//as the project matures, hence all the comments.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour
{
    [SerializeField]
    //TestBaseCharacter needs to be replaced by the final
    //base character script.
    private TestBaseCharacter bc;

    private GuiController gc;

    [SerializeField]
    private Image healthBar,
                  staminaBar;

    void Awake()
    {
        gc = FindObjectOfType<GuiController>();
        gc.StatBarUpdates += SetStatBars;
    }

    void SetStatBars()
    {
        //Opted for this instead of passing int into the event as a parameter.
        //This is because if we give the event a value, it will change the health
        //bar for all of the characters by the same amount. That is not what we want.
        float healthSize = bc.GetHealth() * 0.01f;
        float staminaSize = bc.GetStamina() * 0.01f;

        StartCoroutine(LerpStatBars(healthSize, healthBar));
        //Dosen't work yet. Has weird effect on health bar lerp
        //StartCoroutine(LerpStatBars(staminaSize, staminaBar));
    }

    IEnumerator LerpStatBars(float targetSize, Image statBar)
    {
        float lerpSpeed = 0.1f;
        float currentSize = statBar.rectTransform.localScale.x;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerGui : MonoBehaviour
{
    private TestBaseTower _bt;

    private GuiController _gc;

    [SerializeField]
    private Image _healthBar;

    [SerializeField]
    private Image[] _ammoBar;

    [SerializeField]
    private Sprite _ammoSymbol;

    void Start()
    {
        _bt = GetComponentInParent<TestBaseTower>();
        _gc = FindObjectOfType<GuiController>();

        _gc.StatBarUpdates += SetTowerGui;
    }

    void SetTowerGui()
    {
        float health = _bt.GetHealth();
        float maxHealth = _bt.GetMaxHealth();
        float newSize = health / maxHealth;

        StartCoroutine(LerpHealthBar(newSize));
        SetAmmoGui();
    }
    void SetAmmoGui()
    {
        for (int i = 0; i < _bt.GetMaxAmmo(); i++)
        {
            if (i < _bt.GetAmmo())
            {
                _ammoBar[i].gameObject.SetActive(true);
            }
            else
            {
                _ammoBar[i].gameObject.SetActive(false);
            }
        }
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

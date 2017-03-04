using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBaseTower : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth,
                _health,
                _maxAmmo,
                _ammo;

    private GuiController _gc;

    void Start()
    {
        _gc = FindObjectOfType<GuiController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetHealth(-20);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetHealth(20);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetAmmo(1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetAmmo(-1);
        }
    }

    //Getters
    public int GetHealth()
    {
        return _health;
    }
    public int GetMaxHealth()
    {
        return _maxHealth;
    }
    public int GetAmmo()
    {
        return _ammo;
    }
    public int GetMaxAmmo()
    {
        return _maxAmmo;
    }

    //Setters
    public void SetHealth(int changeAmount)
    {
        _health += changeAmount;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        _gc.UpdateStatBars();
    }
    public void SetAmmo(int changeAmount)
    {
        _ammo += changeAmount;
        _ammo = Mathf.Clamp(_ammo, 0, _maxAmmo);
        _gc.UpdateStatBars();
    }
}

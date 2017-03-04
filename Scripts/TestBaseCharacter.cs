using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBaseCharacter : MonoBehaviour
{
    //This is only for testing
    public KeyCode addHealth;
    public KeyCode subtractHealth;
    public KeyCode addStamina;
    public KeyCode subtractStamina;
    //This is Only for testing

    [SerializeField]
    private int _maxHealth,
                _health,
                _maxStamina,
                _stamina;

    private GuiController _gc;

    void Start()
    {
        _gc = FindObjectOfType<GuiController>();
    }
    void Update()
    {
        //This is only here for testing
        if (Input.GetKeyDown(addHealth))
        {
            SetHealth(20);
        }
        if (Input.GetKeyDown(subtractHealth))
        {
            SetHealth(-20);
        }
        if (Input.GetKeyDown(addStamina))
        {
            SetStamina(20);
        }
        if (Input.GetKeyDown(subtractStamina))
        {
            SetStamina(-20);
        }
        //This is only for testing
    }

    //Getters
    public int GetHealth()
    {
        return _health;
    }
    public int GetStamina()
    {
        return _stamina;
    }
    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    //Setters
    void SetHealth(int changeAmount)
    {
        _health += changeAmount;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        _gc.UpdateStatBars();
    }
    void SetStamina(int changeAmount)
    {
        _stamina += changeAmount;
        _stamina = Mathf.Clamp(_stamina, 0, _maxStamina);
        _gc.UpdateStatBars();
    }
}

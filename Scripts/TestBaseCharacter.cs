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
    private int maxHealth,
                health,
                maxStamina,
                stamina;

    private GuiController gc;

    void Start()
    {
        gc = FindObjectOfType<GuiController>();
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

    public int GetHealth()
    {
        return health;
    }
    public int GetStamina()
    {
        return stamina;
    }

    void SetHealth(int changeAmount)
    {
        health += changeAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        gc.UpdateStatBars();
    }
    void SetStamina(int changeAmount)
    {
        stamina += changeAmount;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        gc.UpdateStatBars();
    }
}

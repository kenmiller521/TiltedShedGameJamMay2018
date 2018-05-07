using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages Health for the player
/// Ruben Sanchez
/// 
/// </summary>

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int startingHealth;

    [SerializeField]
    private GameObject[] moons;

    [SerializeField]
    private UnityEvent onDeath;

    private int currentHealth;

	void Start ()
	{
	    currentHealth = startingHealth;
	}
	
    public void DecrementHealth()
    {
        Destroy(moons[currentHealth - 1]);
        currentHealth--;

        if(currentHealth == 0)
            onDeath.Invoke();
    }
}

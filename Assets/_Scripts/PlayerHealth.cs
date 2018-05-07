using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEditorInternal.VR;
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

    [SerializeField]
    private UnityEvent gameOver;

    private int currentHealth;
    private Coroutine gameOverCoroutine;

	void Start ()
	{
	    currentHealth = startingHealth;
	}
	
    public void DecrementHealth()
    {
        Destroy(moons[currentHealth - 1]);
        currentHealth--;

        if (currentHealth == 0)
        {
            onDeath.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);

        if (gameOverCoroutine == null)
            gameOverCoroutine = StartCoroutine(GameOverDelay());
    }

    public IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2);
        gameOver.Invoke();
        gameOverCoroutine = null;
    }

    public void ZoomInOnWinner()
    {
        ProCamera2D.Instance.DollyZoom(60f, 1f, EaseType.EaseIn);
    }
}

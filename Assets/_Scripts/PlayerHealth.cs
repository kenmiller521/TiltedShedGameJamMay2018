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

    public int playerID;

    private int currentHealth;
    private Coroutine gameOverCoroutine;

	void Start ()
	{
	    currentHealth = startingHealth;
	}
	
    public void DecrementHealth()
    {
        if (currentHealth > 0)
        {
            Destroy(moons[currentHealth - 1]);
            currentHealth--;

            if (currentHealth == 0)
            {
                onDeath.Invoke();
            }
        }
    }

    public void Die()
    {
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

        ProCamera2D.Instance.RemoveCameraTarget(transform, 0f);
        ProCamera2D.Instance.Zoom(-18f, 3.5f, EaseType.EaseIn);

        gameObject.SetActive(false);
    }
}

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

    [SerializeField]
    private float dZoom;

    [SerializeField]
    private float dZoomDuration;

    public int playerID;

    private int currentHealth;
    private Coroutine gameOverCoroutine;

    void Start()
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

    //Not currently working properly
    public void ZoomInOnWinner()
    {

        //ProCamera2D.Instance.RemoveCameraTarget(transform, 0f);
        //ProCamera2D.Instance.Zoom(dZoom, dZoomDuration, EaseType.EaseIn);
        //Invoke("DisableLate", dZoom * 2);
        gameObject.SetActive(false);
    }

    /*private void DisableLate()
    {
        ProCamera2D.Instance.enabled = false;
    }*/

}

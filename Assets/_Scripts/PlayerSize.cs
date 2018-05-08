using UnityEngine;
using System.Collections;
/// <summary>
/// Manages player size with local scale
///
/// Ruben Sanchez
/// 
/// </summary>

public class PlayerSize : MonoBehaviour
 {
    [SerializeField]
    private Vector2 startingLocalScale = Vector2.one;

    [SerializeField]
    private Vector2 minLocalScale = Vector2.one;

    [SerializeField]
    private float scaleChangeSize = .5f;

    [SerializeField]
    private float timeToChange = 1f;

     private void Awake()
     {
         transform.localScale = startingLocalScale;
     }

     public void IncreaseSize()
     {
        Coroutine increase = StartCoroutine(IIncreasable());
     }

     public void DecreaseSize()
     {
        Coroutine decrease = StartCoroutine(IDecreasable());
     }

    public IEnumerator IDecreasable()
    {
        Vector2 targetSize = new Vector2(transform.localScale.x - scaleChangeSize, transform.localScale.y - scaleChangeSize);
        if (transform.localScale.magnitude >= minLocalScale.magnitude)
        {
            while (transform.localScale.magnitude >= targetSize.magnitude)
            {
                if (transform.localScale.magnitude < minLocalScale.magnitude){
                    transform.localScale = minLocalScale;
                    break;
                }
                transform.localScale = new Vector2(transform.localScale.x - .05f, transform.localScale.y - 0.05f);
                yield return new WaitForSeconds(.01f);
            }
        }
    }
    public IEnumerator IIncreasable()
    {
        Vector2 targetSize = new Vector2(transform.localScale.x + scaleChangeSize, transform.localScale.y + scaleChangeSize);
        while (transform.localScale.magnitude <= targetSize.magnitude){
            transform.localScale = new Vector2(transform.localScale.x +.05f, transform.localScale.y + 0.05f);
            yield return new WaitForSeconds(.01f);
        }
    }

}

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

    private CoroutineQueue sizingQueue;

    private void Awake(){ transform.localScale = startingLocalScale; }

    private void Start()
    {
        sizingQueue = new CoroutineQueue(this);
        sizingQueue.StartLoop();
    }

    public void IncreaseSize(){ sizingQueue.EnqueueAction(IIncreasable()); }
    public void DecreaseSize(){ sizingQueue.EnqueueAction(IDecreasable()); }

    public IEnumerator IDecreasable()
    {
        Vector2 targetSize = new Vector2(transform.localScale.x - scaleChangeSize, transform.localScale.y - scaleChangeSize);
        //don't attempt to decrease if player is at the minimum size
        if (transform.localScale.magnitude >= minLocalScale.magnitude){
            while (transform.localScale.magnitude >= targetSize.magnitude){
                //if player hits the minimum size, break
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
        //effectively "lerp" player's size up, called on pickup
        while (transform.localScale.magnitude <= targetSize.magnitude){
            transform.localScale = new Vector2(transform.localScale.x +.05f, transform.localScale.y + 0.05f);
            yield return new WaitForSeconds(.01f);
        }
    }
}

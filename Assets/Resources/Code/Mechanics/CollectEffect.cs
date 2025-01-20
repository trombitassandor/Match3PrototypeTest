using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animatorTriggerName;
    [SerializeField] private TriggerObserver triggerObserver;

    private void Start()
    {
        animator.SetTrigger(animatorTriggerName);

        if (triggerObserver != null)
        {
            triggerObserver.OnTriggerEnter += OnTriggerEnter2D;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Collectible>()?.TryCollect();
    }

    private void OnDestroy()
    {
        if (triggerObserver != null)
        {
            triggerObserver.OnTriggerEnter -= OnTriggerEnter2D;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorInitializer : MonoBehaviour
{
    [SerializeField] private string triggerName;

    private void Awake()
    {
        GetComponent<Animator>().SetTrigger(triggerName);
    }
}

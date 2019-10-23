using UnityEngine;

public class UIChest : MonoBehaviour
{
    [SerializeField] Animator chestsAnimator = null, questionAnimator = null;

    /// <summary>
    /// Called by animation event
    /// </summary>
    public void AnimationOver()
    {
        chestsAnimator.Play("Popup Window Out");
        questionAnimator.Play("Popup Window In");
    }
}

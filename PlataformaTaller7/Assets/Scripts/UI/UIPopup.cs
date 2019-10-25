using UnityEngine;

public class UIPopup : MonoBehaviour
{
    [SerializeField] string popupIn = "", popupOut = "";

    private Animator animator = null;

    private bool isIn = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Change states between in or out
    /// </summary>
    /// <param name="_Value"></param>
    public void PopupAnimation()
    {
        if (!isIn)
        {
            animator.Play(popupIn);
            isIn = true;
        }
        else
        {
            animator.Play(popupOut);
            isIn = false;
        } 
    }
}

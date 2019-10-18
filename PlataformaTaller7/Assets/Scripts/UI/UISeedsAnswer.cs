using UnityEngine;

public class UISeedsAnswer : MonoBehaviour
{
    private void Start()
    {
        LadderManager.Manager.Character.OnReachDestination += ActivateSeeds; 
    }

    private void ActivateSeeds(BoxType _BoxType)
    {
        if (_BoxType == BoxType.Bright)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
        }
    }
}

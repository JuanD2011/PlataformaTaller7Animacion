using UnityEngine;

public class UIButtonExit : UIButtonBase
{
    public override void OnButtonClicked()
    {
        Application.Quit();
    }
}

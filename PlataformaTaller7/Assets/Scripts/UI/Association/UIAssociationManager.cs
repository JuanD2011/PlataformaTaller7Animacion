using UnityEngine;

public class UIAssociationManager : MonoBehaviour
{
    private UIAssociationOptionsManager[] uIAssociationOptionsManagers = new UIAssociationOptionsManager[2];

    [SerializeField]
    private GameObject lines = null;

    private UIAssociationLine[] uIAssociationLines = new UIAssociationLine[4];

    private void Awake()
    {
        uIAssociationLines = lines.GetComponentsInChildren<UIAssociationLine>();
    }

    private void Start()
    {
        QuestionManager.OnAssociationConnected += QuestionManager_OnAssociationConnected;
    }

    private void QuestionManager_OnAssociationConnected(QuestionAnsweredType _QuestionAnsweredType, UIAssociationOption _FirstUIAssociationOption, UIAssociationOption _SecondUIAssociationOption)
    {
        if (_QuestionAnsweredType != QuestionAnsweredType.Correct) return;

        for (int i = 0; i < uIAssociationLines.Length; i++)
        {
            if (!uIAssociationLines[i].IsPlaced)
            {
                uIAssociationLines[i].SetPosition(_FirstUIAssociationOption.transform.localPosition, _SecondUIAssociationOption.transform.localPosition);
                return;
            }
        }
    }
}

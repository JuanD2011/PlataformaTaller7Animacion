using UnityEngine;
using System.Collections.Generic;

public class UIAssociationOptionsManager : MonoBehaviour
{
    [SerializeField] AssociationOptionType associationOptionType = AssociationOptionType.None;

    private List<UIAssociationOption> associationOptions = new List<UIAssociationOption>();

    private List<int> optionsIds = new List<int>() { 0, 1, 2 };

    UIAssociationOption currentUIAssociationOption = null;

    private bool isWrong = false;

    private void Awake()
    {
        associationOptions.AddRange(GetComponentsInChildren<UIAssociationOption>());
    }

    private void Start()
    {
        QuestionManager.OnQuestionAssigned += InitializeOptions;
        QuestionManager.OnAssociationConnected += ManageConnection;

        UIAssociationOption.OnAssociationOptionClicked += ManageOptionUI;
    }

    private void ManageOptionUI(UIAssociationOption _UIAssociationOption)
    {
        if (isWrong) isWrong = false;

        if (!_UIAssociationOption.IsInteractable || isWrong) return;

        if (_UIAssociationOption.AssociationOptionType == associationOptionType)
        {
            if (currentUIAssociationOption != null && currentUIAssociationOption.IsInteractable && currentUIAssociationOption != _UIAssociationOption)
            {
                currentUIAssociationOption.Animate(UIAssociationOption.optionOut, Color.yellow);
            }

            currentUIAssociationOption = _UIAssociationOption;

            currentUIAssociationOption.Animate(UIAssociationOption.optionIn, Color.yellow);
        }
    }

    private void ManageConnection(QuestionAnsweredType _QuestionAnsweredType, UIAssociationOption _FirstUIAssociationOption, UIAssociationOption _SecondUIAssociationOption)
    {
        if (_QuestionAnsweredType == QuestionAnsweredType.Correct)
        {
            if (_FirstUIAssociationOption.AssociationOptionType == associationOptionType)
            {
                _FirstUIAssociationOption.Animate(UIAssociationOption.optionIn, Color.green);
            }
            else if (_SecondUIAssociationOption.AssociationOptionType == associationOptionType)
            {
                _SecondUIAssociationOption.Animate(UIAssociationOption.optionIn, Color.green);
            }
        }
        else if (_QuestionAnsweredType == QuestionAnsweredType.Wrong)
        {
            if (_FirstUIAssociationOption.AssociationOptionType == associationOptionType)
            {
                _FirstUIAssociationOption.Animate(UIAssociationOption.optionOut, Color.red);
            }
            else if (_SecondUIAssociationOption.AssociationOptionType == associationOptionType)
            {
                _SecondUIAssociationOption.Animate(UIAssociationOption.optionOut, Color.red);
            }
            isWrong = true;
        }
        currentUIAssociationOption = null;
    }

    private void InitializeOptions(Question _Question)
    {
        if (_Question.questionType != QuestionType.Association) return;

        Association association = _Question as Association;

        int random = 0;
        int count = 0;

        while (optionsIds.Count > 0)
        {
            random = Random.Range(0, optionsIds.Count);

            if (associationOptionType == AssociationOptionType.Option)
            {
                associationOptions[count].Initialize(optionsIds[random], association.idToKey[optionsIds[random]]);
            }
            else
            {
                associationOptions[count].Initialize(optionsIds[random], association.keyToAnswer[association.idToKey[optionsIds[random]]]);
            }
            count++;

            optionsIds.RemoveAt(random);
        }
    }
}

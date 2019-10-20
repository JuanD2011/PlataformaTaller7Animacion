using UnityEngine;
using System.Collections.Generic;

public class UIAssociationOptionsManager : MonoBehaviour
{
    [SerializeField] AssociationOptionType associationOptionType = AssociationOptionType.None;

    private List<UIAssociationOption> associationOptions = new List<UIAssociationOption>();

    private List<int> optionsIds = new List<int>() { 0, 1, 2, 3 };

    private void Awake()
    {
        associationOptions.AddRange(GetComponentsInChildren<UIAssociationOption>());
    }

    private void Start()
    {
        QuestionManager.OnQuestionAssigned += InitializeOptions;
        QuestionManager.OnAssociationConnected += AnimateAssociation;

        UIAssociationOption.OnAssociationOptionClicked += ManageOptionUI;
    }

    private void ManageOptionUI(AssociationOptionType _AssociationOptionType, int _Id)
    {
        for (int i = 0; i < associationOptions.Count; i++)
        {
            if (associationOptions[i].AssociationOptionType == associationOptionType)
            {

            }
        }
    }

    private void AnimateAssociation(QuestionAnsweredType _QuestionAnsweredType, int _FirstId, int _SecondId)
    {
        if (_QuestionAnsweredType == QuestionAnsweredType.Correct)
        {
            for (int i = 0; i < associationOptions.Count; i++)
            {
                if (associationOptionType == AssociationOptionType.Option)
                {
                    if (associationOptions[i].AssociationOptionType == associationOptionType)
                    {
                        if (associationOptions[i].Id == _FirstId)
                        {
                            associationOptions[i].Animate(UIAssociationOption.optionIn);//TODO verify if I first press the answer and connect it to the option
                        }
                    } 
                }
                else if (associationOptionType == AssociationOptionType.Answer)
                {
                    if (associationOptions[i].AssociationOptionType == associationOptionType)
                    {
                        if (associationOptions[i].Id == _SecondId)
                        {
                            associationOptions[i].Animate(UIAssociationOption.optionIn);
                        }
                    }
                }
            }
        }
        else if (_QuestionAnsweredType == QuestionAnsweredType.Wrong)
        {

        }
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

            associationOptions[count].Initialize(optionsIds[random], association.idToWord[optionsIds[random]]);
            count++;

            optionsIds.RemoveAt(random);
        }
    }
}

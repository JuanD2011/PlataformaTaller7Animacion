using UnityEngine;
using System.Collections.Generic;

public class UIAssociationOptionsManager : MonoBehaviour
{
    private List<UIAssociationOption> associationOptions = new List<UIAssociationOption>();

    private List<int> optionsIds = new List<int>() { 0, 1, 2, 3 };

    private void Awake()
    {
        associationOptions.AddRange(GetComponentsInChildren<UIAssociationOption>());
    }

    private void Start()
    {
        QuestionManager.OnQuestionAssigned += InitializeOptions;
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

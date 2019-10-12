using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestionsDataBase))]
public class QuestionDataBaseEditor : Editor
{
    QuestionsDataBase questionsDataBase = null;

    SerializedProperty questions;

    MultipleChoice multipleChoice = null;

    private void OnEnable()
    {
        questionsDataBase = (QuestionsDataBase)target;
        questions = serializedObject.FindProperty("questions");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Multiple choice")) questionsDataBase.CreateQuestion(QuestionType.MultipleChoice);
        if (GUILayout.Button("True or False")) questionsDataBase.CreateQuestion(QuestionType.TrueOrFalse);
        if (GUILayout.Button("Association")) questionsDataBase.CreateQuestion(QuestionType.Association);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(questions, true);

        serializedObject.ApplyModifiedProperties();
    }
}

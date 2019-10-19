using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAssociationOption : MonoBehaviour
{
    [SerializeField] AssociationOptionType associationOptionType = AssociationOptionType.None;
    private int id = 0;

    private Button m_Button = null;
    private TextMeshProUGUI m_Text = null;

    public static event Delegates.Action<AssociationOptionType, int> OnAssociationOptionClicked = null;

    private void Awake()
    {
        OnAssociationOptionClicked = null;

        m_Text = GetComponentInChildren<TextMeshProUGUI>();
        m_Button = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        m_Button.onClick.AddListener(() => OnAssociationOptionClicked(associationOptionType, id));
    }

    /// <summary>
    /// Set id and text
    /// </summary>
    public void Initialize(int _Id, string _TextValue)
    {
        id = _Id;
        m_Text.text = _TextValue;
    }
}

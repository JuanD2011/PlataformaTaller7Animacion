using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAssociationOption : MonoBehaviour
{
    [SerializeField] AssociationOptionType associationOptionType = AssociationOptionType.None;

    private Button m_Button = null;
    private TextMeshProUGUI m_Text = null;
    private Animator m_Animator = null;
    private Image background = null;

    public const string optionIn = "Option In";
    public const string optionOut = "Option Out";

    public static event Delegates.Action<UIAssociationOption> OnAssociationOptionClicked = null;

    public AssociationOptionType AssociationOptionType { get => associationOptionType; private set => associationOptionType = value; }
    public int Id { get; private set; } = 0;
    public bool IsInteractable { get; private set; } = true;

    private void Awake()
    {
        OnAssociationOptionClicked = null;

        background = GetComponentInChildren<Image>();
        m_Text = GetComponentInChildren<TextMeshProUGUI>();
        m_Button = GetComponentInChildren<Button>();
        m_Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        m_Button.onClick.AddListener(() =>
        {
            if (IsInteractable)
            {
                OnAssociationOptionClicked(this); 
            }
        });
    }

    /// <summary>
    /// Set id and text
    /// </summary>
    public void Initialize(int _Id, string _TextValue)
    {
        IsInteractable = true;
        Id = _Id;
        m_Text.text = _TextValue;
    }

    /// <summary>
    /// Play the state given
    /// </summary>
    /// <param name="_StateName"></param>
    public void Animate(string _StateName, Color _ImageColor)
    {
        background.color = _ImageColor;
        m_Animator.Play(_StateName);
    }

    /// <summary>
    /// Set trigger
    /// </summary>
    /// <param name="_Id"></param>
    public void SetTrigger(string _Id)
    {
        m_Animator.SetTrigger(_Id);
    }

    /// <summary>
    /// Set interactability
    /// </summary>
    public void SetInteractability(bool _Value)
    {
        IsInteractable = _Value;
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Users Database", menuName = "Users Database")]
public class UsersDatabase : ScriptableObject
{
    [SerializeField]
    private User[] users = new User[4];

    public User[] Users { get => users; private set => users = value; }

    public static User CurrentUser { get; set; } = null;
}

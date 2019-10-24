[System.Serializable]
public class UserProperty
{
    public bool male = true;

    /// <summary>
    /// Changing between male and female
    /// </summary>
    public void ChangeGenre() => male = male ? male = false : male = true;
}
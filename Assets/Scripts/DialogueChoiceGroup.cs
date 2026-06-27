[System.Serializable]
public class DialogueChoice
{
    public string text;

    public int wealthPoints;
    public int susPoints;
    public int pedoPoints;
    // todo more point categories...

    public string responseText;

}

[System.Serializable]
public class DialogueChoiceGroup
{
    public DialogueChoice[] options = new DialogueChoice[0];
}
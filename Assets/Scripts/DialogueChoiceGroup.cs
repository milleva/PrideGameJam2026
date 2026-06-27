[System.Serializable]
public enum DialogueResultingState
{
    happy,
    angry,
    neutral
}

[System.Serializable]
public class DialogueChoice
{
    public string text;

    public int wealthPoints;
    public int susPoints;
    public int pedoPoints;
    // todo more point categories...

    public DialogueResultingState resultingState;

    public string responseText;

}

[System.Serializable]
public class DialogueChoiceGroup
{
    public DialogueChoice[] options = new DialogueChoice[0];
}
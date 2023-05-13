using UnityEngine;

public class HelpTextHUDBehaviour : HUDBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    public void SetText(string text)
    {
        _text.text = text;
    }
}

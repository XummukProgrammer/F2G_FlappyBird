using UnityEngine;

public class DebugWindowTabButtonBehaviour : MonoBehaviour
{
    public delegate void ClickedDelegate(string name);

    public ClickedDelegate Clicked;

    [SerializeField] private TMPro.TMP_Text _name;

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void OnClick()
    {
        Clicked?.Invoke(_name.text);
    }
}

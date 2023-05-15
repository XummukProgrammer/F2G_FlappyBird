using UnityEngine;

public class ResourceHUDBehaviour : HUDBehaviour
{
    [SerializeField] private TMPro.TMP_Text _name;
    [SerializeField] private TMPro.TMP_Text _value;

    public void SetName(string name)
    {
        if (_name)
        {
            _name.text = name;
        }
    }

    public void SetValue(int value)
    {
        if (_value)
        {
            _value.text = value.ToString();
        }
    }
}

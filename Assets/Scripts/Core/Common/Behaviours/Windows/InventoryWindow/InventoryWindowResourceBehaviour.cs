using UnityEngine;

public class InventoryWindowResourceBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _name;
    [SerializeField] private TMPro.TMP_Text _value;

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetValue(int value)
    {
        _value.text = value.ToString();
    }
}

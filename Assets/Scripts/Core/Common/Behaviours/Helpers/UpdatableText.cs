using UnityEngine;

public class UpdatableText : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    public void SetText(string text)
    {
        _text.text = text;

        // Update
        _text.gameObject.SetActive(false);
        _text.gameObject.SetActive(true);
    }
}

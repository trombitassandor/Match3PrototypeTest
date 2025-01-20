using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AmountTextGui : MonoBehaviour
{
    private TextMeshProUGUI textGui;

    private uint amount;

    public uint Amount
    {
        get => amount;
        set
        {
            amount = value;
            textGui.text = value == 0 ? "X" : $"x{value}";
        }
    }

    private void Awake()
    {
        textGui = GetComponent<TextMeshProUGUI>();
    }
}

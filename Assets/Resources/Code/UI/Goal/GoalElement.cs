using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalElement : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private AmountTextGui textGui;
    [SerializeField] private GameObject fadeGameObject;

    private uint currentAmount;

    private uint CurrentAmount
    {
        get => currentAmount;
        set
        {
            currentAmount = value;
            textGui.Amount = value;
            fadeGameObject.SetActive(value == 0);
        }
    }

    public void Init(Sprite sprite, uint amount)
    {
        image.sprite = sprite;
        CurrentAmount = amount;
    }

    public void TryDecreaseAmount()
    {
        if (CurrentAmount > 0)
        {
            --CurrentAmount; 
        }
    }
}

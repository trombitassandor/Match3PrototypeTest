using UnityEngine;

public class MovesGui : MonoBehaviour
{
    [SerializeField] private AmountTextGui amountTextGui;

    public void Init(uint movesAmount)
    {
        amountTextGui.Amount = movesAmount;
    }

    public void TryDecreaseMoves()
    {
        if (amountTextGui.Amount > 0)
        {
            --amountTextGui.Amount;
        }
    }
}

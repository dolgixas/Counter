using UnityEngine;
using TMPro;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    public void UpdateCounterText(int count)
    {
        if (_counterText != null)
        {
            _counterText.text = "Count: " + count;
        }
    }
}

using UnityEngine;
using TMPro;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Counter _counter; 

    private void OnEnable()
    {
        if (_counter != null)
        {
            _counter.OnCountUpdated += UpdateCounterText;
        }
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.OnCountUpdated -= UpdateCounterText; 
        }
    }

    public void UpdateCounterText(int count)
    {
        if (_counterText != null)
        {
            _counterText.text = "Count: " + count;
        }
    }
}

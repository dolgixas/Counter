using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterDisplay _counterDisplay; 

    private int _count;
    private Coroutine _countingCoroutine;
    private const float _countInterval = 0.5f;

    private void Start()
    {
        InitializeCounter();
    }

    private void Update()
    {
        HandleInput();
    }

    private void InitializeCounter()
    {
        _count = 0;
        _counterDisplay.UpdateCounterText(_count); 
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private void ToggleCounting()
    {
        if (_countingCoroutine == null)
        {
            StartCounting();
        }
        else
        {
            StopCounting();
        }
    }

    private void StartCounting()
    {
        _countingCoroutine = StartCoroutine(Count());
    }

    private void StopCounting()
    {
        StopCoroutine(_countingCoroutine);
        _countingCoroutine = null;
    }

    private IEnumerator Count()
    {
        while (CanContinueCounting())
        {
            yield return new WaitForSeconds(_countInterval);
            IncrementCount();
        }
    }

    private bool CanContinueCounting()
    {
        return true;
    }

    private void IncrementCount()
    {
        _count++;
        _counterDisplay.UpdateCounterText(_count); 
        Debug.Log("Count: " + _count);
    }
}

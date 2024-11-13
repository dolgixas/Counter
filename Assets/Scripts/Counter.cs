using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    public delegate void CountUpdated(int count);
    public event CountUpdated OnCountUpdated;

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
        OnCountUpdated?.Invoke(_count); 
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
        while (enabled) 
        {
            yield return new WaitForSeconds(_countInterval);
            IncrementCount();
        }
    }

    private void IncrementCount()
    {
        _count++;
        OnCountUpdated?.Invoke(_count); 
        Debug.Log("Count: " + _count);
    }
}

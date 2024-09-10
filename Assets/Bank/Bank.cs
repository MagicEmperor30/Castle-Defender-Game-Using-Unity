using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get{return currentBalance; } }
    
    void Awake()
    {
        currentBalance = startingBalance;
        updateDisplay();
    }

    private void updateDisplay()
    {
        displayBalance.text = "Gold :"+ currentBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        updateDisplay();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        updateDisplay();

        if(currentBalance < 0)
        {
            ReloadScene();
        }
    }    
    void ReloadScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

}

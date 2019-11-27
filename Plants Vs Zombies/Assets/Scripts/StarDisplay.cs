using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    public enum Status { SUCCESS, FAILURE }

    private Text starText;
    private int totalStars = 100;

    public void Start()
    {
        starText = gameObject.GetComponent<Text>();
        UpdateDisplay();
    }

    public void AddStars(int amount)
    {
        totalStars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if(totalStars >= amount)
        {
            totalStars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
        
        
        
    }

    private void UpdateDisplay()
    {
        starText.text = totalStars.ToString();
    }

}

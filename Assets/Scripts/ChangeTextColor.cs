using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class ChangeTextColor : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Color targetColor = Color.green;
    public string inputKey = "a"; // The default key is 'a'

    private void Start()
    {
        // Ensure the TextMeshPro component is assigned
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        // Set the initial color to white
        textMeshPro.color = Color.white;
    }

    private void Update()
    {
        // Check for the specified input key
        if (Input.GetKey(inputKey))
        {
            // Change the text color to the target color (green)
            textMeshPro.color = targetColor;
        }
        else
        {
            // Revert the text color to white
            textMeshPro.color = Color.white;
        }
    }
}


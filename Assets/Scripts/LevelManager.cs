using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int endScene;

    [SerializeField] public float yBoundary;
    [SerializeField] public float xBoundary;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = Vector3.zero;
        player.GetComponent<PlayerMovement>().xBoundary = xBoundary;
        player.GetComponent<PlayerMovement>().yBoundary = yBoundary;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        if (SceneManager.GetActiveScene().buildIndex == endScene)
        {
            Debug.Log("haha u won idiott pls close game");
            Application.Quit();
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    public GameObject mainMenuUI;

    void Awake()
    {
        mainMenuUI = GameObject.Find("MainMenuCanvas");
    }
    // Start is called before the first frame update
    void Start()
    {
        mainMenuUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
    }
}

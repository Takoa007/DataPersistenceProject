using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMan : MonoBehaviour
{
    public static StartMan instance;
    public string PlayerName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
}

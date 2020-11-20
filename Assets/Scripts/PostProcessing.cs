using UnityEngine;


public sealed class PostProcessing : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

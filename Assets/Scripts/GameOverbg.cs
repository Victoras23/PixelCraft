using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverbg : MonoBehaviour
{
    public void start()
    {
        gameObject.SetActive(false);
    }
    public void set()
    {
        gameObject.SetActive(true);
    }

}

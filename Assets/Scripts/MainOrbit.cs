using UnityEngine;
using UnityEngine.SceneManagement;
public class MainOrbit : Orbit{
    private void Update () { if (integrity) SceneManager.LoadScene("Scenes/Victory"); } 
}
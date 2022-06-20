using UnityEngine;
using UnityEngine.SceneManagement;
public class MainOrbit : Orbit{
    private void OnTriggerEnter(Collider collider) { if (Integrity) SceneManager.LoadScene("Scenes/Victory"); } 
}
using UnityEngine;
public class RingSegment : MonoBehaviour{
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material deselectedMaterial;
    
    private bool selected;
    public bool Selected {
        get => Selected = selected;
        private set {
            selected = value;
            var mat = gameObject.GetComponentInChildren<Renderer>().material;
            mat.EnableKeyword("_EMISSION");
            mat = value ? selectedMaterial : deselectedMaterial;
            gameObject.GetComponentInChildren<Renderer>().material = mat;
        }
    }
    private void SetMaterial() {
        gameObject.GetComponentInChildren<Renderer>().material = selectedMaterial;
    }
    public Orbit orbit { get; private set; }
    private void Update() { 
        SetMaterial();
        if (!Selected) return;
        if (Input.GetKeyDown(KeyCode.UpArrow)) Up();
        if (Input.GetKeyDown(KeyCode.DownArrow)) Down();
    }
    private void StickToOrbit(Component orbit) {
        var t = transform;
        var pos = t.localPosition;
        t.localPosition = new Vector3(pos.x, orbit.transform.localPosition.y, pos.z);
    }
    public void OnTriggerEnter(Collider collider) {
        orbit = collider.gameObject.GetComponent<Orbit>(); StickToOrbit(orbit);
    }
    public void Up() { if (orbit.gameObject.CompareTag($"Upper Orbit") || !selected) return;
        var t = transform; var pos = t.localPosition;
        t.localPosition = new Vector3(pos.x,pos.y + 0.5f,pos.z);
    }
    public void Down() { if (orbit.gameObject.CompareTag($"Lower Orbit") || !selected) return;
        var t = transform;
        var pos = t.localPosition;
        t.localPosition = new Vector3(pos.x,pos.y - 0.5f,pos.z);
    }
    public void Toggle() { Selected = !Selected; }
}
using UnityEngine;
using UnityEditor;

public class AddMaterial : MonoBehaviour {

    public float x;
    public float y;
    public Vector3 pos;
    public Vector2 sizes;

    public  Vector2 _scale;

    void OnEnable()
    {
        _scale.x = transform.localScale.x;
        _scale.y = transform.localScale.y;
        Debug.Log(_scale.x);
    }

    public void AddWaverMaterial() {
        var material = new Material(Shader.Find("Custom/SpriteWaver"));
        AssetDatabase.CreateAsset(material, "Assets/Materials/" + Selection.activeGameObject.name + ".mat");
        Selection.activeGameObject.GetComponent<Renderer>().sharedMaterial = material;
    }

    void OnDrawGizmosSelected()
    { 
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(pos, new Vector3(sizes.x*_scale.x, sizes.y*_scale.y, 1));
    }
}

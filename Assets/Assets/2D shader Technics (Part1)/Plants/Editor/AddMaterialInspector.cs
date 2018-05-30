using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(AddMaterial))]
public class AddMaterialInspector : Editor
{
    private Vector2 _spriteSize;

    AddMaterial material;
    public override void OnInspectorGUI()
    {
        material = target as AddMaterial;
        if(GUILayout.Button("Add Waver Material"))
        {
            material.AddWaverMaterial();
        }

        _spriteSize.x = material.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        _spriteSize.y = material.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
       
        EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("X Coordinate",GUILayout.MaxWidth(100));
                material.x = GUILayout.HorizontalSlider(material.x, 0, _spriteSize.x*3 );
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Y Coordinate", GUILayout.MaxWidth(100));
                material.y = GUILayout.HorizontalSlider(material.y, 0, _spriteSize.y*3  );
            EditorGUILayout.EndHorizontal();
            material.sizes = EditorGUILayout.Vector2Field("", material.sizes);
            material.pos = new Vector3(material.transform.position.x + material.x, material.transform.position.y  - material.y , 0.0f);
        

        if (EditorGUI.EndChangeCheck())
        {
            float sourceX = material.transform.position.x;
            float sourceY = material.transform.position.y;

            float distanceY = Vector2.Distance(new Vector2(0,material.pos.y),new Vector2(0,sourceY));
            float distanceX = Vector2.Distance(new Vector2(material.pos.x,0),new Vector2(sourceX,0));

            material.gameObject.GetComponent<Renderer>().sharedMaterial.SetVector("_Rect", new Vector4(distanceX  - (material.sizes.x*material._scale.x) / 2, distanceX + (material.sizes.x*material._scale.x) / 2, -distanceY + (material.sizes.y*material._scale.y) / 2, -distanceY - (material.sizes.y * material._scale.y) / 2));
            SceneView.RepaintAll();
        }
    }

}


using UnityEngine;
using UnityEditor;

#if true
[CustomEditor(typeof(MegaMeshPage))]
public class MegaMeshPageEditor : Editor
{
	[MenuItem("GameObject/Create Other/MegaShape/Page Mesh")]
	static void CreatePageMesh()
	{
		Vector3 pos = UnityEditor.SceneView.lastActiveSceneView.pivot;

		GameObject go = new GameObject("Page Mesh");
		
		MeshFilter mf = go.AddComponent<MeshFilter>();
		mf.sharedMesh = new Mesh();
		MeshRenderer mr = go.AddComponent<MeshRenderer>();

		Material[] mats = new Material[3];

		mr.sharedMaterials = mats;
		MegaMeshPage pm = go.AddComponent<MegaMeshPage>();

		go.transform.position = pos;
		Selection.activeObject = go;
		pm.Rebuild();
	}

	public override void OnInspectorGUI()
	{
		MegaMeshPage mod = (MegaMeshPage)target;

		//bool rebuild = DrawDefaultInspector();
#if !UNITY_5 && !UNITY_2017 && !UNITY_2018 && !UNITY_2019 && !UNITY_2020 && !UNITY_2021
		EditorGUIUtility.LookLikeControls();
#endif

		mod.Width = EditorGUILayout.FloatField("Width", mod.Width);
		mod.Length = EditorGUILayout.FloatField("Length", mod.Length);
		mod.Height = EditorGUILayout.FloatField("Height", mod.Height);
		mod.WidthSegs = EditorGUILayout.IntField("Width Segs", mod.WidthSegs);
		mod.LengthSegs = EditorGUILayout.IntField("Length Segs", mod.LengthSegs);
		mod.HeightSegs = EditorGUILayout.IntField("Height Segs", mod.HeightSegs);
		mod.genUVs = EditorGUILayout.Toggle("Gen UVs", mod.genUVs);
		mod.rotate = EditorGUILayout.FloatField("Rotate", mod.rotate);
		mod.PivotBase = EditorGUILayout.Toggle("Pivot Base", mod.PivotBase);
		mod.PivotEdge = EditorGUILayout.Toggle("Pivot Edge", mod.PivotEdge);
		mod.tangents = EditorGUILayout.Toggle("Tangents", mod.tangents);
#if UNITY_5_5 || UNITY_5_6 || UNITY_2017 || UNITY_2018 || UNITY_2019 || UNITY_2020 || UNITY_2021
#else
		mod.optimize = EditorGUILayout.Toggle("Optimize", mod.optimize);
#endif

		if ( GUI.changed )	//rebuild )
			mod.Rebuild();
	}
}
#endif
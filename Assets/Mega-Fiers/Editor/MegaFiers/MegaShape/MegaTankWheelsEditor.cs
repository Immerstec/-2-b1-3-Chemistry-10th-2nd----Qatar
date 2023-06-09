
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MegaTankWheels))]
public class MegaTankWheelsEditor : Editor
{
	public override void OnInspectorGUI()
	{
#if !UNITY_5 && !UNITY_2017 && !UNITY_2018 && !UNITY_2019 && !UNITY_2020 && !UNITY_2021
		EditorGUIUtility.LookLikeControls();
#endif
		DrawDefaultInspector();
	}

#if UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_2017 || UNITY_2018 || UNITY_2019 || UNITY_2020 || UNITY_2021
	[DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Pickable | GizmoType.InSelectionHierarchy)]
#else
	[DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Pickable | GizmoType.InSelectionHierarchy)]
#endif
	static void RenderGizmo(MegaTankWheels track, GizmoType gizmoType)
	{
		if ( (gizmoType & GizmoType.Active) != 0 && Selection.activeObject == track.gameObject )
		{
			Gizmos.matrix = track.transform.localToWorldMatrix;
			Gizmos.DrawWireSphere(Vector3.zero, track.radius);
		}
	}
}
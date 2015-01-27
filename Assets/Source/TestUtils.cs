using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TestUtils
{
	public static GameObject CreateTestSphere(Vector3 pos, float scale = 1f)
	{
		var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		go.collider.enabled = false;
		go.transform.position = pos;
		go.transform.localScale = new Vector3(scale, scale, scale);
		return go;
	}

	public static IEnumerable<GameObject> CreateSpheres(Vector3 startPos, int num, float scatterRad)
	{
		var spheresGo = new GameObject();
		spheresGo.gameObject.name = "Spheres";
		var spheres = new List<GameObject>();
		for (int i = 0; i < num; i++)
		{
			var pos = UnityEngine.Random.insideUnitSphere * scatterRad;
			var sphere = CreateTestSphere(pos + startPos, 0.1f);
			sphere.transform.parent = spheresGo.transform;
			spheres.Add(sphere);
		}
		return spheres;
	}


	public static bool Vec3Equal(Vector3 a, Vector3 b)
	{
		if (!Mathf.Approximately(a.x, b.x)) return false;
		if (!Mathf.Approximately(a.y, b.y)) return false;
		if (!Mathf.Approximately(a.z, b.z)) return false;
		return true;
	}
}

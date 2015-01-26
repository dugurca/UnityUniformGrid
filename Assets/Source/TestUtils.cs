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
}

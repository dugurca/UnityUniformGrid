using UnityEngine;
using System.Collections;

public static class Extensions
{
	public static void ResetTransform(this Transform trans)
	{
		trans.position = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale = Vector3.one;
	}

	public static Vector3 SetVec3(float val)
	{
		return new Vector3(val, val, val);
	}
}

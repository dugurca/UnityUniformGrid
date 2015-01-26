using System.Collections.Generic;
using UnityEngine;

public class GridTests : MonoBehaviour
{
	private GameObject _uniformGrid;
	private int _numVoxels = 8;
	private float _voxelSize = 1f;

	private 

	void Start()
	{
		_uniformGrid = UniformGrid.CreateUniformGrid(Vector3.zero, _numVoxels, _voxelSize);
		Debug.LogWarning(GridUtils.GridStartPos(_uniformGrid.transform.position, _numVoxels, _voxelSize));
		Debug.LogWarning(GridUtils.GridEndPos(_uniformGrid.transform.position, _numVoxels, _voxelSize));

		var spheres = CreateSpheres(_uniformGrid.transform.position, 100, 10f);
		CheckSpheres(spheres);

	}

	void CheckSpheres(IEnumerable<GameObject> spheres)
	{
		foreach (var sphere in spheres)
		{
			if (GridUtils.InGrid(sphere.transform.position, _uniformGrid.transform.position, _numVoxels, _voxelSize))
			{
				sphere.renderer.material.color = Color.red;
			}
			else
			{
				sphere.renderer.material.color = Color.white;
			}
		}
	}

	IEnumerable<GameObject> CreateSpheres(Vector3 startPos, int num, float scatterRad)
	{
		var spheresGo = new GameObject();
		spheresGo.gameObject.name = "Spheres";
		var spheres = new List<GameObject>();
		for (int i = 0; i < num; i++)
		{
			var pos = UnityEngine.Random.insideUnitSphere * scatterRad;
			var sphere = TestUtils.CreateTestSphere(pos + startPos, 0.1f);
			sphere.transform.parent = spheresGo.transform;
			spheres.Add(sphere);
		}
		return spheres;
	}

	void OnDrawGizmos()
	{
		if (!_uniformGrid) return;
		var sp = GridUtils.GridStartPos(_uniformGrid.transform.position, _numVoxels, _voxelSize);
		var ep = GridUtils.GridEndPos(_uniformGrid.transform.position, _numVoxels, _voxelSize);

		const float scale = 0.25f;

		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(sp, scale);

		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(ep, scale);
	}

}

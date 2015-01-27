using System.Collections.Generic;
using UnityEngine;

public class GridTests : MonoBehaviour
{

	void Start()
	{
		//SpheresTest();
		GridPosTest1(Vector3.zero, 4, 1f);
		GridPosTest2(Vector3.zero, 3, 0.1f);
	}

	private void SpheresTest()
	{
		const int numVoxels = 8;
		const float voxelSize = 1f;

		var uniformGrid = UniformGrid.CreateUniformGrid(Vector3.zero, numVoxels, voxelSize);
		Debug.LogWarning(GridUtils.GridStartPos(uniformGrid.transform.position, numVoxels, voxelSize));
		Debug.LogWarning(GridUtils.GridEndPos(uniformGrid.transform.position, numVoxels, voxelSize));

		var spheres = TestUtils.CreateSpheres(uniformGrid.transform.position, 100, 10f);
		CheckSpheres(uniformGrid, spheres, numVoxels, voxelSize);
	}

	void CheckSpheres(GameObject uniformGrid, IEnumerable<GameObject> spheres, int numVoxels, float voxelSize)
	{
		foreach (var sphere in spheres)
		{
			if (GridUtils.InGrid(sphere.transform.position, uniformGrid.transform.position, numVoxels, voxelSize))
			{
				sphere.renderer.material.color = Color.red;
			}
			else
			{
				sphere.renderer.material.color = Color.white;
			}
		}
	}

	private void GridPosTest1(Vector3 startPos, int numVox, float voxSize)
	{
		var testGrid = UniformGrid.CreateUniformGrid(startPos, numVox, voxSize);

		Vector3 p1 = new Vector3(0.4f, 0.5f, 0.6f);
		int p1Voxel = GridUtils.World2Voxel(p1, testGrid.transform.position, numVox, voxSize);
		Debug.Log(p1Voxel);
		System.Diagnostics.Debug.Assert(p1Voxel == 0);

		Vector3 voxPos = GridUtils.VoxelPosition(testGrid.transform.position, numVox, voxSize, p1Voxel);
		Debug.Log(voxPos);
		System.Diagnostics.Debug.Assert(TestUtils.Vec3Equal(voxPos, new Vector3(0.5f, 0.5f, 0.5f)));
	}

	private void GridPosTest2(Vector3 startPos, int numVox, float voxSize)
	{
		var testGrid = UniformGrid.CreateUniformGrid(startPos, numVox, voxSize);

		Vector3 p1 = new Vector3(0.05f, 0.12f, 0.07f);
		int p1Voxel = GridUtils.World2Voxel(p1, testGrid.transform.position, numVox, voxSize);
		Debug.Log(p1Voxel);
		System.Diagnostics.Debug.Assert(p1Voxel == 9);

		Vector3 voxPos = GridUtils.VoxelPosition(testGrid.transform.position, numVox, voxSize, p1Voxel);
		Debug.Log(voxPos);
		System.Diagnostics.Debug.Assert(TestUtils.Vec3Equal(voxPos, new Vector3(0.05f, 0.15f, 0.05f)));
	}

	

	//void OnDrawGizmos()
	//{
	//	if (!_uniformGrid) return;

	//	int numVoxels = 8;
	//	float voxelSize = 1f;

	//	var sp = GridUtils.GridStartPos(_uniformGrid.transform.position, numVoxels, voxelSize);
	//	var ep = GridUtils.GridEndPos(_uniformGrid.transform.position, numVoxels, voxelSize);

	//	const float scale = 0.25f;

	//	Gizmos.color = Color.yellow;
	//	Gizmos.DrawSphere(sp, scale);

	//	Gizmos.color = Color.cyan;
	//	Gizmos.DrawSphere(ep, scale);
	//}
}

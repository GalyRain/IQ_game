using UnityEngine;

namespace Model.Level_2
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFiveLevel2 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[5];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 7f);
            blocks[2] = new Vector3(3f, 7f);
            blocks[3] = new Vector3(3f, 10f);
            blocks[4] = new Vector3(6.5f, 6.5f);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2, 2, 3, 4, 0, 2, 4 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
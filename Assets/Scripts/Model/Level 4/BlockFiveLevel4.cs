using UnityEngine;

namespace Model.Level_4
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFiveLevel4 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[6];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 2f);
            blocks[2] = new Vector3(4f, 4f);
            blocks[3] = new Vector3(8f, -4f);
            blocks[4] = new Vector3(4f, -4f);
            blocks[5] = new Vector3(4f, 0);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2, 0, 2, 5, 5, 2, 3, 5, 3, 4 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
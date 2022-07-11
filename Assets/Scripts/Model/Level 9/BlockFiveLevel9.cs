using UnityEngine;

namespace Model.Level_9
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFiveLevel9 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[5];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(6f, 0);
            blocks[2] = new Vector3(3.5f, 2.5f);
            blocks[3] = new Vector3(2f, 1f);
            blocks[4] = new Vector3(0, 3f);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 1, 2, 3, 1, 3, 0, 0, 3, 4 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
using UnityEngine;

namespace Model.Level_5
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFiveLevel5 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[9];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(1f, 0f);
            blocks[2] = new Vector3(-3f, 8f);
            blocks[3] = new Vector3(-4f, 8f);
            blocks[4] = new Vector3(-4f, 4f);
            blocks[5] = new Vector3(-5f, 4f);
            blocks[6] = new Vector3(-1f, -4f);
            blocks[7] = new Vector3(0, -4f);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5, 0, 5, 6, 0, 6, 7 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
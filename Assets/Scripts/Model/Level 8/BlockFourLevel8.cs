using UnityEngine;

namespace Model.Level_8
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFourLevel8 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[5];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 4f);
            blocks[2] = new Vector3(4f, 8f);
            blocks[3] = new Vector3(7f, 5f);
            blocks[4] = new Vector3(1f, -1f);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
using UnityEngine;

namespace Model.Level_4
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFourLevel4 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[3];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 10f);
            blocks[2] = new Vector3(4f, 2f);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
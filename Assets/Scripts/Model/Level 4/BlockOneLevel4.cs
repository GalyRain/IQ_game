using UnityEngine;

namespace Model.Level_4
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockOneLevel4 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[4];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 4f);
            blocks[2] = new Vector3(4f, 4f);
            blocks[3] = new Vector3(4f, 0);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2, 0, 2, 3 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
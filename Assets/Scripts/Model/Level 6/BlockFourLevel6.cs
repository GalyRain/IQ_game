using UnityEngine;

namespace Model.Level_6
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFourLevel6 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[4];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(7.5f, 0);
            blocks[2] = new Vector3(2f, 3f);
            blocks[3] = new Vector3(0, 3f);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2, 0, 2, 3 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
using UnityEngine;

namespace Model.Level_2
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFourLevel2 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[5];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 4.9f);
            blocks[2] = new Vector3(2.1f, 7f);
            blocks[3] = new Vector3(4.2f, 4.9f);
            blocks[4] = new Vector3(4.2f, 0);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
using UnityEngine;

namespace Model.Level_9
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockOneLevel9 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[6];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(-1.5f, 1.5f);
            blocks[2] = new Vector3(0f, 3f);
            blocks[3] = new Vector3(6f, 3f);
            blocks[4] = new Vector3(4.5f, 1.5f);
            blocks[5] = new Vector3(6f, 0f);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
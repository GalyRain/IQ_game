using UnityEngine;

namespace Model.Level_9
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockThreeLevel9 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[3];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 6f);
            blocks[2] = new Vector3(6f, 0);

            mesh.vertices = blocks;

            mesh.triangles = new[] { 1, 0, 2 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
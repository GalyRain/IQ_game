using UnityEngine;

namespace Model
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFour : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[5];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 2.24f);
            blocks[2] = new Vector3(0.56f, 1.68f);
            blocks[3] = new Vector3(0.8f, 1.92f);
            blocks[4] = new Vector3(0.8f, 0.8f);
            
            mesh.vertices = blocks;
            
            mesh.triangles = new[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
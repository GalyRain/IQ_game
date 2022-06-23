using UnityEngine;

namespace Model.Level_1
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BlockFourLevel1 : MonoBehaviour
    {
        [SerializeField] private Material material;
        private void Start()
        {
            Mesh mesh = new Mesh();
            Vector3[] blocks = new Vector3[5];
            blocks[0] = new Vector3(0, 0);
            blocks[1] = new Vector3(0, 8.96f);
            blocks[2] = new Vector3(2.24f, 6.72f);
            blocks[3] = new Vector3(3.2f, 7.68f);
            blocks[4] = new Vector3(3.2f, 3.2f);
            
            mesh.vertices = blocks;
            
            mesh.triangles = new[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };

            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material = material;
        }
    }
}
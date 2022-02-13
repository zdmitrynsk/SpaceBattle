using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class AntiRotateByParent : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        private Vector3 startPostition;


        private void Awake()
        {
            startPostition = transform.localPosition;
        }

        private void Update()
        {
            AntiRotate_Rotation();
            AntiRotate_Position();
        }

        private void AntiRotate_Rotation()
        {
            gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -parent.transform.rotation.z);
        }

        private void AntiRotate_Position()
        {
            Vector3 rotationAngeles = new Vector3(0, 0, -parent.transform.rotation.eulerAngles.z);
            transform.localPosition = RotatePointAroundPivot(startPostition, Vector3.zero, rotationAngeles);
        }

        Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles){
            Vector3 dir = point - pivot; 
            dir = Quaternion.Euler(angles) * dir; 
            point = dir + pivot; 
            return point; 
        }
    }
}

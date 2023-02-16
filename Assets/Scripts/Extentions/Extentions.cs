using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Exteions
{
    public static class Extentions 
    {
        public static Vector3 GetClickPos(this Camera camera)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 50f))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        public static RaycastHit GetClickPos(this Camera camera,float maxDistance)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 50f))
            {
                return hit;
            }

            return hit;
        }
        public static RaycastHit GetClickPos(this Camera camera,float maxDistance, LayerMask layer)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            int layerMask = 1 << layer;


            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
            {
                Debug.Log(hit.transform.gameObject.name);
                Debug.DrawRay(camera.transform.position, ray.direction * 52, Color.red, 655);
                return hit;
            }

            return hit;
        }
        public static Transform GetClickTransform(this Camera camera, float maxDistance, LayerMask layer)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            int layerMask = 1 << layer;

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
            {
                return hit.transform;
            }


            return null;
        }
        public static Vector3 GetClickPos(this Camera camera, int maxDistance)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
               
                return hit.point;
            }

            return hit.point;
        }
        public static Vector3 GetClickPos(this Camera camera, LayerMask layerMask)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 50f))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        public static void FollowUIElementToMousePosition(this RectTransform canvasRect, RectTransform uiObjectRectTransform,Vector2 mousePos)
        {
            Vector2 mousePosition = Input.mousePosition;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, mousePosition, null, out Vector2 localPosition);

            uiObjectRectTransform.localPosition= localPosition;
        }

        public static Vector3 GetRandomPointOnCylinder(this Transform transform, GameObject cylinder)
        {
            if (transform is null)
            {
                //throw new System.ArgumentNullException(nameof(transform));
            }

            if (cylinder is null)
            {
                //throw new System.ArgumentNullException(nameof(cylinder));
            }

            float angle = Random.Range(0f, 360f);
            float y = cylinder.transform.localScale.y / 2+ 1.5f + cylinder.transform.position.y;
            float x = Random.Range(0, cylinder.transform.localScale.x/2 * Mathf.Cos(angle * Mathf.Deg2Rad));
            float z = Random.Range(0, cylinder.transform.localScale.z/2 * Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector3 randomPoint = new Vector3(x, y, z) + cylinder.transform.position;

            return randomPoint;
        }
        public static Vector3 GetRandomTargetOnCylinder(this GameObject cylinder)
        {
            float angle = Random.Range(0f, 360f);
            float y = cylinder.transform.localScale.y / 2 + 1.5f + cylinder.transform.position.y;
            float x = Random.Range(0, cylinder.transform.localScale.x / 2 * Mathf.Cos(angle * Mathf.Deg2Rad));
            float z = Random.Range(0, cylinder.transform.localScale.z / 2 * Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector3 randomPoint = new Vector3(x, y, z) + cylinder.transform.position;

            return randomPoint;
        }
        public static Quaternion RotateAsPosition(this Transform transformRotate, Vector3 target, float speed)
        {
            Vector3 shotPosition = new Vector3(target.x, target.y, target.z);
            Vector3 relativePos = shotPosition - new Vector3(transformRotate.position.x, transformRotate.position.y, transformRotate.position.z);
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            return Quaternion.Lerp(transformRotate.localRotation, rotation, speed); 
        }

        public static float AngelAsPivot(this Transform transform, Vector3 pivotPosition, Vector3 targetTransform,Vector3 pivotDirection)
        {
            return Vector3.Angle(pivotPosition - targetTransform, pivotDirection);
        }
        public static bool Between(this float num, int lower, int upper)
        {
            return lower <= num && num < upper;
        }

        public static bool IsElementExitCamera(this Camera camera,GameObject gameObject)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

            return GeometryUtility.TestPlanesAABB(planes, gameObject.GetComponent<Collider>().bounds);
        }
        public static bool IsElementExitCamera(this Camera camera, Collider gameObject)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

            return GeometryUtility.TestPlanesAABB(planes, gameObject.GetComponent<Collider>().bounds);
        }
    }
}


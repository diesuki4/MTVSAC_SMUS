using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MoveOnThePlane : MonoBehaviour
{
    RaycastHit hit, hitLayerMask;
    GameObject objectHitPosition;
    Transform parent;
    float yHeight;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(this.transform.position, this.transform.localRotation * Vector3.up * 3.0f);
    }

    Vector3 getContactPoint(Vector3 normal, Vector3 planeDot, Vector3 A, Vector3 B)
    {
        Vector3 nAB = (B - A).normalized;

        return A + nAB * Vector3.Dot(normal, planeDot - A) / Vector3.Dot(normal, nAB);
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layer = 1 << LayerMask.NameToLayer("Stage");
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            objectHitPosition = new GameObject("HitPosition");
            objectHitPosition.transform.position = hit.point;
            print(hit.point);
            this.transform.SetParent(objectHitPosition.transform);
        }
    }

    void OnMouseUp()
    {
        this.transform.parent = parent;
        Destroy(objectHitPosition);
    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        int layer = 1 << LayerMask.NameToLayer("Stage");
        if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layer))
        {
            int x = (int)(hitLayerMask.point.x);
            int z = (int)(hitLayerMask.point.z);
            objectHitPosition.transform.position = new Vector3(x , hitLayerMask.point.y, z);
            Debug.DrawRay(ray.origin, ray.direction * (ray.origin -  hitLayerMask.point).magnitude, Color.red);
            return;
            Vector3 normal = hitLayerMask.transform.up;
            Vector3 planeDot = hitLayerMask.point + hitLayerMask.collider.transform.up * yHeight;
            Vector3 A = Camera.main.transform.position;
            Vector3 B = hitLayerMask.point;

            this.transform.rotation
              = Quaternion.LookRotation(hitLayerMask.collider.transform.forward);
            Vector3 v = getContactPoint(normal, planeDot, A, B);
            objectHitPosition.transform.position = getContactPoint(normal, planeDot, A, B);
            //float x = (int)Mathf.FloorToInt(objectHitPosition.transform.position.x);
            //float y = (int)Mathf.FloorToInt(objectHitPosition.transform.position.y) ;
            //float z = (int)Mathf.FloorToInt(objectHitPosition.transform.position.z);
            //objectHitPosition.transform.position = new Vector3(x, y, z);
        }
    }

    void Start()
    {
        parent = transform.parent.transform;
        yHeight = this.transform.localScale.y;
    }

}
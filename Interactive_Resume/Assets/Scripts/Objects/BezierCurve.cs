using UnityEngine;

[System.Serializable]
public class BezierCurve
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;

    public float GetPoint(float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 pAB = u * pointA.position + t * pointB.position;
        Vector3 pCD = u * pointC.position + t * pointD.position;
        Vector3 pABCD = u * pAB + t * pCD;

        Vector3 pBC = u * pointB.position + t * pointC.position;
        Vector3 pABC = u * pAB + t * pBC;

        return Mathf.Lerp(pABCD.y, pABC.y, tt);
    }
}
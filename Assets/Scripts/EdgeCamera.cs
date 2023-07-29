using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCamera : MonoBehaviour
{
    public static EdgeCamera Instance { get; private set; }
    static Vector3 CameraShakeOffset;

    public Transform RightCamera;
    public Transform LeftCamera;

    bool Started;
    Vector3 PosVel, RotVel;

    Vector3 CurrentPos;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CurrentPos = transform.position;
    }

    void Update()
    {
        if(!Started)
        {
            if(!Game.Instance.Joining)
            {
                Started = true;
            }
        }
        else
        {
            float averageX = 0;
            float numOfPlayers = 0;
            foreach (Player player in FindObjectsOfType<Player>())
            {
                numOfPlayers++;
                averageX += player.transform.position.x;
            }
            averageX /= numOfPlayers;


            Vector3 targetPosition = Vector3.Lerp(LeftCamera.transform.position, RightCamera.transform.position, (averageX + 4.0f) / 44f);
            Quaternion targetRotation = Quaternion.Lerp(LeftCamera.transform.rotation, RightCamera.transform.rotation, (averageX + 4.0f) / 44f);
            CurrentPos = Vector3.SmoothDamp(CurrentPos, targetPosition, ref PosVel, 0.3f);
            transform.rotation = SmoothDampQuaternion(transform.rotation, targetRotation, ref RotVel, 0.3f);

            transform.position = CurrentPos + CameraShakeOffset;
        }
    }

    public static Quaternion SmoothDampQuaternion(Quaternion current, Quaternion target, ref Vector3 currentVelocity, float smoothTime)
    {
        Vector3 c = current.eulerAngles;
        Vector3 t = target.eulerAngles;
        return Quaternion.Euler(
          Mathf.SmoothDampAngle(c.x, t.x, ref currentVelocity.x, smoothTime),
          Mathf.SmoothDampAngle(c.y, t.y, ref currentVelocity.y, smoothTime),
          Mathf.SmoothDampAngle(c.z, t.z, ref currentVelocity.z, smoothTime)
        );
    }

    public static void CameraShake(float _strength, float _time)
    {
        Instance.StartCoroutine(Instance.CameraShakeRoutine(_strength, _time));
    }

    IEnumerator CameraShakeRoutine(float _strength, float _time)
    {
        float count = 0;
        while (count < _time)
        {
            float currentStrength = ((_time - count) / _time) * _strength;
            CameraShakeOffset = currentStrength * Random.onUnitSphere;

            count += Time.unscaledDeltaTime;
            yield return null;
        }
        CameraShakeOffset = Vector3.zero;
    }
}

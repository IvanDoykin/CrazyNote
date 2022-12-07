using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class TimeZonesView : MonoBehaviour
    {
        [SerializeField] private Transform _destroyZone;
        [SerializeField] private Transform _detectZone;
        [SerializeField] private Transform _triggerZone;
        [SerializeField] private Transform _undetectZone;

        private void OnEnable()
        {
            float speed = GriefSettings.Speed * 6.255f;

            _undetectZone.transform.localScale = new Vector3(1f, 1f, (NotesHandler.TimeToDetect) * speed);
            _undetectZone.transform.localPosition = new Vector3(0f, 0f, _undetectZone.transform.localScale.z / 2);

            _detectZone.transform.localScale = new Vector3(1f, 1f, (NotesHandler.TimeToTrigger - NotesHandler.TimeToDetect) * speed);
            _detectZone.transform.localPosition = new Vector3(0f, 0f, (_undetectZone.transform.localPosition.z + _undetectZone.transform.localScale.z / 2) + _detectZone.transform.localScale.z / 2f);

            _triggerZone.transform.localScale = new Vector3(1f, 1f, (NotesHandler.TimeToDestroy - NotesHandler.TimeToTrigger) * speed);
            _triggerZone.transform.localPosition = new Vector3(0f, 0f, (_detectZone.transform.localPosition.z + _detectZone.transform.localScale.z / 2) + _triggerZone.transform.localScale.z / 2f);

            _destroyZone.transform.localScale = new Vector3(1f, 1f, (NotesHandler.TimeToDestroy - NotesHandler.TimeToDestroy) * speed);
            _destroyZone.transform.localPosition = new Vector3(0f, 0f, (_triggerZone.transform.localPosition.z + _triggerZone.transform.localScale.z / 2) + _destroyZone.transform.localScale.z / 2f + 0.25f);
            _destroyZone.transform.localScale += new Vector3(0f, 0f, 0.5f);
        }
    }
}
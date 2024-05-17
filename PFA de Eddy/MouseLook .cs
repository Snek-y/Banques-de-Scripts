using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class MouseLook
    {
        public void LookRotation(Transform character, Transform camera)
        {
            float mouseYRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            float mouseXRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            float joystickYRot = CrossPlatformInputManager.GetAxis("RightJoystickX") * XSensitivity;
            float joystickXRot = CrossPlatformInputManager.GetAxis("RightJoystickY") * YSensitivity;

            float yRot = mouseYRot + joystickYRot;
            float xRot = mouseXRot + joystickXRot;

            m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);
        }
    }
}
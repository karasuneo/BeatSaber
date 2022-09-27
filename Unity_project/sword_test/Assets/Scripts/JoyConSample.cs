using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JoyConSample : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues (typeof (Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    private Joycon.Button? m_pressedButtonL;
    private Joycon.Button? m_pressedButtonR;

    private GameObject sheep;

    [SerializeField]
    private GameObject nozzle;

    private void Start ()
    {
        SetControllers ();

        sheep = GameObject.Find ("BeamSheep");
    }

    private void Update ()
    {
        m_pressedButtonL = null;
        m_pressedButtonR = null;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        SetControllers ();

        foreach (var button in m_buttons)
        {
            if (m_joyconL.GetButton (button))
            {
                m_pressedButtonL = button;
            }
            if (m_joyconR.GetButton (button))
            {
                m_pressedButtonR = button;
            }
        }

        if (Input.GetKeyDown (KeyCode.Z))
        {
            m_joyconL.SetRumble (160, 320, 0.6f, 200);
        }
        if (Input.GetKeyDown (KeyCode.X))
        {
            m_joyconR.SetRumble (160, 320, 0.6f, 200);
        }

        const float MOVE_PER_CLOCK = 0.01f;
        Vector3 joyconGyro;

        joyconGyro = m_joyconR.GetGyro ();
        Quaternion sheepQuaternion = sheep.transform.rotation;
        sheepQuaternion.x += -joyconGyro[0] * MOVE_PER_CLOCK;
        sheepQuaternion.y -= -joyconGyro[2] * MOVE_PER_CLOCK;
        sheepQuaternion.z -= -joyconGyro[1] * MOVE_PER_CLOCK;
        sheep.transform.rotation = sheepQuaternion;

        if (m_joyconR.GetButtonDown (m_buttons[0]))
        {
            sheep.transform.rotation = new Quaternion (0, 0, 0, 0);
        }

        if (m_joyconR.GetButtonDown (m_buttons[1]))
        {
            if (nozzle.activeSelf)
            {
                nozzle.SetActive (false);
            }
            else
            {
                nozzle.SetActive (true);
            }
        }
    }

    private void SetControllers ()
    {
        m_joycons = JoyconManager.Instance.j;
        if (m_joycons == null || m_joycons.Count <= 0) return;
        m_joyconL = m_joycons.Find (c => c.isLeft);
        m_joyconR = m_joycons.Find (c => !c.isLeft);
    }
}

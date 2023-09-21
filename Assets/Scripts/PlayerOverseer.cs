using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerOverseer : ScriptableObject
{
    public float[] floats;
    public int currentWeapon;
    public List<int> _swordHeavyAttacks = new List<int>();

    public List<Vector3> _weaponNormalPositions = new List<Vector3>();
    public List<Quaternion> _weaponNormalRotations = new List<Quaternion>();
    public List<Transform> _weaponTrans = new List<Transform>();
}

using System;
using UnityEngine;

namespace Maze
{
    [Serializable]
    public struct SVect3 
    {
        public float X;
        public float Y;
        public float Z;

        public SVect3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator SVect3(Vector3 val)
        {
            return new SVect3(val.x, val.y, val.z);
        }
        public static implicit operator Vector3(SVect3 val)
        {
            return new Vector3(val.X, val.Y, val.Z);
        }
    }

    [Serializable]
    public struct SQuaternion
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public SQuaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator SQuaternion(Quaternion val)
        {
            return new SQuaternion(val.x, val.y, val.z, val.w);
        }
        public static implicit operator Quaternion(SQuaternion val)
        {
            return new Quaternion(val.X, val.Y, val.Z, val.W);
        }
    }

    [Serializable]
    public struct SColor
    {
        float R;
        float G;
        float B;
        float A;

      public SColor(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;

        }
        public static implicit operator SColor(Color  color)
        {
            return new SColor(color.r, color.g, color.b, color.a);
        }
        public static implicit operator Color(SColor color)
        {
            return new Color(color.R, color.G, color.B, color.A);
        }
    }



    [Serializable]
    public struct SObject
    {
        public string Name;
        public SVect3 Position;
        public SQuaternion Rotation;
        public SColor BonusColor;
        public float HightOfFly;
        public float SpeedOfRotation;

    }

    [Serializable]
    public struct PlayerData
    {
        public string PlayerName;
        public int PlayerHealth;
        public bool PlayerDead;
        public SVect3 PlayerPosition;
        public SVect3 PlayerScale;
        public SColor PlayerColor;
    }
}

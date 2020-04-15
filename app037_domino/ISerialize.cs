using System;
using System.IO;

interface ISerialize
{
    object Deserialize(BinaryReader br);
    void Serialize(BinaryWriter bw);
}




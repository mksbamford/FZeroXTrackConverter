using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FZeroX
{
    public class BigEndianBinaryWriter : BinaryWriter
    {
        public override void Write(byte[] buffer)
        {
            Array.Reverse(buffer);
            base.Write(buffer);
        }
        /*
        public override void Write(string value)
        {
            char[] array = value.ToCharArray();
            Array.Reverse(array);
            base.Write(array);
        }
        */
    }
}

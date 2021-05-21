using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLife.Utilities
{
    public static class RandomInt
    {

        public static int GetRandom(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min value is greater or equals than Max value.");
            }
            byte[] intBytes = new byte[4];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(intBytes);
            }
            return min + Math.Abs(BitConverter.ToInt32(intBytes, 0)) % (max - min + 1);
        }
    }
}

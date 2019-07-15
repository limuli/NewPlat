using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.Security
{
    class Pbkdf2
    {
        private readonly int blocksize;
        private uint blockindex = 1;

        private byte[] baBuffer;
        private int bufferstartindex = 0;
        private int bufferendindex = 0;

        public Pbkdf2(HMAC algorithm, Byte[] password, Byte[] salt, Int32 iterations)
        {
            if (algorithm == null) { throw new ArgumentNullException("algorithm", "HMAC algorithm cannot be null."); }
            if (salt == null) { throw new ArgumentNullException("salt", "Salt cannot be null."); }
            if (password == null) { throw new ArgumentNullException("password", "Password cannot be null."); }
            this.hmacAlg = algorithm;
            this.hmacAlg.Key = password;
            this.salt = salt;
            this.itercount = iterations;
            this.blocksize = this.hmacAlg.HashSize / 8;
            this.baBuffer = new byte[this.blocksize];
        }

        public HMAC hmacAlg { get; private set; }

        public Byte[] salt { get; private set; }

        public Int32 itercount { get; private set; }

        public Byte[] getBytes(int count)
        {
            byte[] result = new byte[count];
            int resultOffset = 0;
            int bufferCount = this.bufferendindex - this.bufferstartindex;

            if (bufferCount > 0)
            { //if there is some data in buffer
                if (count < bufferCount)
                { //if there is enough data in buffer
                    Buffer.BlockCopy(this.baBuffer, this.bufferstartindex, result, 0, count);
                    this.bufferstartindex += count;
                    return result;
                }
                Buffer.BlockCopy(this.baBuffer, this.bufferstartindex, result, 0, bufferCount);
                this.bufferstartindex = this.bufferendindex = 0;
                resultOffset += bufferCount;
            }

            while (resultOffset < count)
            {
                int needCount = count - resultOffset;
                this.baBuffer = this.DoPbkdf2();
                if (needCount > this.blocksize)
                { //we one (or more) additional passes
                    Buffer.BlockCopy(this.baBuffer, 0, result, resultOffset, this.blocksize);
                    resultOffset += this.blocksize;
                }
                else
                {
                    Buffer.BlockCopy(this.baBuffer, 0, result, resultOffset, needCount);
                    this.bufferstartindex = needCount;
                    this.bufferendindex = this.blocksize;
                    return result;
                }
            }
            return result;
        }

        private byte[] DoPbkdf2()
        {
            var hash1Input = new byte[this.salt.Length + 4];
            Buffer.BlockCopy(this.salt, 0, hash1Input, 0, this.salt.Length);
            Buffer.BlockCopy(GetBytesFromInt(this.blockindex), 0, hash1Input, this.salt.Length, 4);
            var hash1 = this.hmacAlg.ComputeHash(hash1Input);

            byte[] finalHash = hash1;
            for (int i = 2; i <= this.itercount; i++)
            {
                hash1 = this.hmacAlg.ComputeHash(hash1, 0, hash1.Length);
                for (int j = 0; j < this.blocksize; j++)
                {
                    finalHash[j] = (byte)(finalHash[j] ^ hash1[j]);
                }
            }
            if (this.blockindex == uint.MaxValue) { throw new InvalidOperationException("Derived key too long."); }
            this.blockindex += 1;

            return finalHash;
        }

        private static byte[] GetBytesFromInt(uint i)
        {
            var bytes = BitConverter.GetBytes(i);
            if (BitConverter.IsLittleEndian)
            {
                return new byte[] { bytes[3], bytes[2], bytes[1], bytes[0] };
            }
            else
            {
                return bytes;
            }
        }
    }
}

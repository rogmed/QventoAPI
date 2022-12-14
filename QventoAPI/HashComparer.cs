using System.Security.Cryptography;
using System.Text;
using HashLib;

namespace QventoAPI
{

    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class HashHandler
    {
        public bool Compare(string passwordHash, string password)
        {
            var sha3512 = HashFactory.Crypto.SHA3.CreateKeccak512();

            //Create a byte array from source data
            var tmpSource = sha3512.ComputeString(password);

            //Compute hash based on source data
            var tmpHash = tmpSource.ToString();

            if (passwordHash.Length == tmpHash.Length)
            {
                int i = 0;
                while ((i < passwordHash.Length) && (passwordHash[i] == tmpHash[i]))
                {
                    i += 1;
                }

                if (i == passwordHash.Length)
                {
                    return true;
                }
            }

            return false;
        }

        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }

}

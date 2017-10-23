using System.Text;

namespace CodeTestApp.Cryptography
{
    internal class CustomCryp
    {
        internal static string CreateHash(byte[] data)
        {
            var hexArray = Encoding.UTF8.GetBytes("0123456789ABCDEF".ToCharArray());
            byte[] hexChars = new byte[data.Length * 2];

            for (int y = 0; y < data.Length; y++)
            {
                var yValue = data[y];
                var x = yValue & 0xFF;
                hexChars[y * 2] = hexArray[x >> 4];
                hexChars[y * 2 + 1] = (byte)(x & 0x0F);
            }

            return Encoding.UTF8.GetString(hexChars);
        }
    }
}

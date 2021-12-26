using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace RSA_KEY_GEN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key_Size = input_size("Key Size");
            int block_Size = input_size("Block Size");

            string gen_key = keySize(key_Size);
            string gen_block = keySize(block_Size);
            Console.WriteLine("\n<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
            Console.WriteLine("The generated Key is:  "+ gen_key );
            Console.WriteLine("\n<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
            Console.WriteLine("\nThe generated IV is:  " +gen_block);
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>\n");
            Console.WriteLine("Key Hex");
            Hex_Conversion(gen_key);
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>\n");
            Console.WriteLine("IV Hex");
            Hex_Conversion(gen_block);
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");


        }
        // Gets user input and converts to a int for the next method
        public static int input_size(string msg)
        {
            Console.WriteLine("Enter the {0}:", msg);
            int temp = Convert.ToInt32(Console.ReadLine());

            return temp;

        }
        //gets user input for key size and block size uses those to generate a specific byte length output 
        public static string keySize(int msg)
        {
            if (msg == 256)
            {
                //generated a key with 32 bytes
                byte[] key = new byte[32];
                RandomNumberGenerator rng = RandomNumberGenerator.Create();
                rng.GetBytes(key);
                //converts byte array to a string and returns the value
                string convertKey = Convert.ToBase64String(key);                
                return convertKey;
            }
            else if (msg == 192)
            {
                byte[] key = new byte[24];
                RandomNumberGenerator rng = RandomNumberGenerator.Create();
                rng.GetBytes(key);
                string convertKey = Convert.ToBase64String(key);
                return convertKey;
            }
            else if (msg == 128)
            {
                byte[] key = new byte[16];
                RandomNumberGenerator rng = RandomNumberGenerator.Create();
                rng.GetBytes(key);
                string convertKey = Convert.ToBase64String(key);
                return convertKey;
            }
            else
            {
                Console.WriteLine("Not a vaild key size. Please enter 256, 192, or 128.");
                return null;
            }
        }
        public static byte[] Hex_Conversion(string msg)
        {
            //converts arguments to their hexidecimial values 
            byte[] tempbytes = Encoding.Default.GetBytes(msg);
            string hexString = BitConverter.ToString(tempbytes);
            hexString = hexString.Replace("-", "");
            List<String> list = new List<String>();
            int NumberChars = hexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            foreach (byte b in bytes)
            {
                String forString = String.Format("0X{0:X}", b);
                list.Add(forString);
            }
            Console.WriteLine(string.Join(", ", list));




            return bytes;
        }     
    }
}

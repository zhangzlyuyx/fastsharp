using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ret = FastSharp.Core.Util.CryptoUtils.EncodeSha256("");
            Console.WriteLine(ret.ToString());
            Console.ReadLine();
        }
    }
}

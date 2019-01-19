using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JZExample
{
    public class SendHelper
    {
        public static void SendVR(Stream stream)
        {
            var msg = "{~FR|}";
            Send(stream, msg);
        }

        public static void SendDc(Stream stream)
        {
            var msg = "{~DC0|}";
            Send(stream, msg);
        }

        public static void SendJobUpdate(Stream stream)
        {
            //var msg = "{~JU0||001|tt1|Fuck world|tt2|bing}";
            var msg = "{~JU0||001|QR|iLikeTomato1129|}";
            Send(stream, msg);

        }

        public static void SelectTt2(Stream stream)
        {
            var msg = "{~JS0|tt2|1|tt1|Fuck world|}";
            Send(stream, msg);
        }

        public static void UpdateDefaultJob(Stream stream)
        {
            var msg = "{~JU0||001|Field1|Fuck you|Field2|Hello world|}";
            Send(stream, msg);

        }

        public static void SendJobSelect(Stream stream)
        {
            var msg = "{~JS0|3911|1|}";
            Send(stream, msg);
        }

        public static void Send(Stream stream, string package)
        {
            var bytes = System.Text.Encoding.ASCII.GetBytes(package);
            //var bytes = System.Text.Encoding.UTF8.GetBytes(jsPacket);
            stream.Write(bytes, 0, bytes.Length);

            var readerBuffer = new byte[10240];
            var readBytes = stream.Read(readerBuffer, 0, 10240);
            var text = System.Text.Encoding.UTF8.GetString(readerBuffer);
            Console.WriteLine();
        }
    }
}

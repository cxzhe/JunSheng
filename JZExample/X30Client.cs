using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace JZExample
{
    //Print Status Request
    //~PS|0|

//   5.21 Print Status Response
//Sent by NGE device to report if device head is ready to print
//Response Field Field Length Notes
//Message Identifier ~PR
//Message Body
//Status 1 character Optional
//Print Status 1 character
//0 – Ready to print
//1 – Unable to print, incorrect state
//2 – Unable to print, printing
//3 – Unable to print, fault
//Example
//~PR0|
//~PR0|0| (if ‘Status’ field enabled)

    public enum PrinterStatus
    {
        ReadyToPrint = 0,
        IncorrectState = 1,
        Printing = 2,
        Fault = 3
    }

    public class X30Client
    {
        private const int PORT = 21000;
        public TcpClient TcpClient { get; private set; }

        public Encoding Encoding { get; private set; } = Encoding.UTF8;

        public X30Client()
        {
            TcpClient = new TcpClient();
        }

        public async Task<PrinterStatus> GetPrinterStatusAsync()
        {
            var packet = "{~PS|0|}";
            var response = await SendAsync(TcpClient, packet, Encoding);

            //sample response {~PR0|0|}
            if(response.StartsWith("{~PR0|") && response.Length > 6)
            {
                var statusChar = response[6];
                int statusValue = Convert.ToInt32(statusChar) - Convert.ToInt32('0');
                if (statusValue >= 0 && statusValue <= 3)
                {
                    return (PrinterStatus)statusValue;
                }
            }
            throw new InvalidDataException();
        }

        public async Task UpdateJob(JobCommand command)
        {
            var packet = command.ToPacket();
            var response = await SendAsync(TcpClient, packet, Encoding);
            if(response != "{~JU0|}")
            {
                throw new InvalidOperationException();
            }
        }

        private async Task<string> SendAsync(TcpClient tcpClient, string package, Encoding encoding)
        {
            using (var stream = tcpClient.GetStream())
            {
                var bytes = encoding.GetBytes(package);
                await stream.WriteAsync(bytes, 0, bytes.Length);

                var bufferSize = 1024 * 8;
                var readerBuffer = new byte[bufferSize];
                var count = await stream.ReadAsync(readerBuffer, 0, bufferSize);
                var text = encoding.GetString(readerBuffer, 0, count);
                return text;
            }
        }

    }
}

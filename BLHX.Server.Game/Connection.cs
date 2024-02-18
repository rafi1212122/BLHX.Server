using BLHX.Server.Common.Utils;
using System.Net;
using System.Net.Sockets;

namespace BLHX.Server.Game
{
    public class Connection
    {
        readonly TcpClient tcpClient;
        readonly Logger c;
        readonly CancellationTokenSource cts = new();
        readonly Task loopTask;
        public IPEndPoint EndPoint => (IPEndPoint)tcpClient.Client.RemoteEndPoint!;

        public Connection(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            c = new(EndPoint.ToString());
            loopTask = Task.Run(ClientLoop, cts.Token);
        }

        private async Task ClientLoop()
        {
            var ns = tcpClient.GetStream();
            var buf = GC.AllocateUninitializedArray<byte>(8 << 13);
            var pos = 0;

            while (!cts.Token.IsCancellationRequested)
            {
                await Task.Delay(1);
                int len = ns.Read(buf, pos, buf.Length - pos);
                len += pos;
                if (len == 0)
                    continue;

                c.Debug(BitConverter.ToString(buf[..len]).Replace("-", ""));
            }
        }

        public void EndProtocol()
        {
            cts.Cancel();
            loopTask.Wait();
            loopTask.Dispose();

            tcpClient.Dispose();
        }
    }
}

using BHXY.Server.Common.Proto.p10;
using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game.Handlers
{
    internal static class P10
    {
        #region GateCommands
        [PacketHandler(Command.Cs10800)]
        static void Cs10800Handler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs10800>();
            connection.Send(new Sc10801()
            {
                GatewayIp = Config.Instance.Address,
                GatewayPort = Config.Instance.Port,
                Url = "http://" + Config.Instance.Address,
                ProxyIp = Config.Instance.Address,
                ProxyPort = Config.Instance.Port,
                Versions = [
                    "$azhash$7$1$459$470aa097fec844d6",
                    "$cvhash$467$98edcdd4e7dac668",
                    "$l2dhash$514$b59cdb747b1c64c9",
                    "$pichash$15$0d6f59289972cc8a",
                    "$bgmhash$13$76fdc897426a138d",
                    "$paintinghash$82$6daa07fa50583c60",
                    "$mangahash$24$3cefad85368b3296",
                    "$cipherhash$24$3cefad85368b3296",
                    "dTag-1"
                ],
                Timestamp = (uint)DateTimeOffset.Now.ToUnixTimeSeconds(),
                Monday0oclockTimestamp = 1606114800
            });
            connection.EndProtocol();
        }

        [PacketHandler(Command.Cs10020)]
        static void Cs10020Handler(Connection connection, Packet packet)
        {
            // Arg2 uid
            // Arg3 accessToken
            // CheckKey md5(Arg1 + salt)
            var req = packet.Decode<Cs10020>();
            connection.Send(new Sc10021()
            {
                Result = 0,
                AccountId = uint.Parse(req.Arg2),
                Serverlists = [
                    new Serverinfo()
                    {
                        Ids = [0],
                        Name = "BLHX.Server",
                        Ip = Config.Instance.Address,
                        Port = Config.Instance.Port,
                        ProxyIp = Config.Instance.Address,
                        ProxyPort = Config.Instance.Port
                    }
                ],
                ServerTicket = req.Arg3
            });
            connection.EndProtocol();
        }
        #endregion

        [PacketHandler(Command.Cs10022)]
        static void Cs10022Handler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs10022>();
            var rsp = new Sc10023();

            var account = DBManager.AccountContext.Accounts.SingleOrDefault(x => x.Uid == req.AccountId);
            if (account is null)
            {
                rsp.Result = 1;
                connection.Send(rsp);
                return;
            }
            // TODO: Create/access player data!
            connection.Send(rsp);
        }
    }
}

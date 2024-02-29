using BLHX.Server.Common.Proto.p10;
using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Data;

namespace BLHX.Server.Game.Handlers
{
    internal static class P10
    {
        #region GateCommands
        [PacketHandler(Command.Cs10800)]
        static void VersionHandler(Connection connection, Packet packet)
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
                Monday0oclockTimestamp = Connection.Monday0oclockTimestamp
            });
            connection.EndProtocol();
        }

        [PacketHandler(Command.Cs10020)]
        static void UserLoginHandler(Connection connection, Packet packet)
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
        static void ServerLoginHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs10022>();
            var rsp = new Sc10023();

            var account = DBManager.AccountContext.Accounts.SingleOrDefault(x => x.Uid == req.AccountId);
            if (account is null || account.Token != req.ServerTicket)
            {
                rsp.Result = 1;
                connection.Send(rsp);
                connection.EndProtocol();
                return;
            }

            connection.account = account;
            rsp.ServerTicket = req.ServerTicket;

            var player = DBManager.PlayerContext.Players.SingleOrDefault(x => x.Token == req.ServerTicket);
            if (player is null)
            {
                connection.Send(rsp);
                return;
            }

            DBManager.PlayerContext.PlayerRoutine(player);
            connection.player = player;
            rsp.UserId = player.Uid;
            connection.Send(rsp);
        }

        [PacketHandler(Command.Cs10024)]
        static void CreateNewPlayerHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs10024>();
            var rsp = new Sc10025();
            if (connection.player is not null)
            {
                rsp.Result = 1011;
                connection.Send(rsp);
                return;
            }

            var player = DBManager.PlayerContext.Init(connection.account.Token, req.ShipId, req.NickName);
            connection.player = player;
            rsp.UserId = connection.player.Uid;
            connection.Send(rsp);
        }

        [PacketHandler(Command.Cs10100, IsNotifyHandler = true)]
        static void HeartbeatHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc10101());
            connection.Tick();
        }
    }
}

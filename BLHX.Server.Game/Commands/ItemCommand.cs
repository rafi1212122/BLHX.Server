using BLHX.Server.Common.Data;
using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto.common;
using BLHX.Server.Game.Handlers;
using System.Numerics;

namespace BLHX.Server.Game.Commands {
    [CommandHandler("item", "Unlock an item or all items", "item unlock=all amount=1")]
    public class ItemCommand : Command {
        [Argument("unlock")]
        public string? Unlock { get; set; }

        [Argument("amount")]
        public string? Amount { get; set; }

        public override void Execute(Dictionary<string, string> args, Connection connection) {
            base.Execute(args);

            //uint amount = 1;

            //if (Amount is not null) {
            //    uint.TryParse(Amount, out uint parsedAmount);
            //    amount = parsedAmount;
            //}

            //if (Unlock is not null) {
            //    if (Unlock.Equals("all", StringComparison.CurrentCultureIgnoreCase)) {
            //        // ...
            //    } else if (uint.TryParse(Unlock, out uint itemId)) {
            //        //connection.player.DoResource(itemId, amount);
            //        PlayerResource? item = DBManager.PlayerContext.Resources.Where(res => res.Id == itemId).FirstOrDefault();

            //        if (item is null) {
            //            DBManager.PlayerContext.Resources.Add(new PlayerResource() { Id = itemId, PlayerUid = connection.player.Uid, Num = 1 });
            //            //connection.player.DoResource(itemId, 1);

            //            //item = DBManager.PlayerContext.Resources.Where(res => res.Id == itemId).FirstOrDefault();
            //        } else {
            //            item.Num += amount;
            //            connection.SendSystemMsg($"{amount} item of itemid: {itemId} added!");
            //        }


            //    } else {
            //        connection.SendSystemMsg($"Invalid ItemId: {itemId}");
            //    }
            //}

            connection.player.DoResource(1, 938493849);
            connection.player.DoResource(4, 39843294);



            DBManager.PlayerContext.Save();
            connection.NotifyPlayerData();
            connection.NotifyBagData();
            base.NotifySuccess(connection);
        }
    }
}

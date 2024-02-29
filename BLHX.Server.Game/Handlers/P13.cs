using BLHX.Server.Common.Data;
using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p13;
using BLHX.Server.Common.Utils;
using System.Numerics;

namespace BLHX.Server.Game.Handlers
{
    internal static class P13
    {
        [PacketHandler(Command.Cs13101, SaveDataAfterRun = true)]
        static void TrackingHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs13101>();
            var rsp = new Sc13102();
            if (!Data.ChapterTemplate.TryGetValue((int)req.Id, out var chapterTemplate))
            {
                rsp.Result = 1;
                connection.Send(rsp);
                return;
            }

            connection.player.DoResource(2, chapterTemplate.Oil * -1);

            var cells = chapterTemplate.GridItems.Select(x =>
            {
                var cellInfo = new Chaptercellinfo()
                {
                    Pos = new Chaptercellpos() { Column = x.Column, Row = x.Row }
                };

                if (x.Flag == ChapterAttachFlag.AttachEnemy)
                {
                    cellInfo.ItemType = (uint)x.Flag;
                    // TODO: Use weigted values
                    cellInfo.ItemId = (uint)chapterTemplate.ExpeditionIdWeightList[Random.Shared.Next(chapterTemplate.ExpeditionIdWeightList.Length)][0];
                }

                if (x.Flag == ChapterAttachFlag.AttachBoss && chapterTemplate.BossRefresh == 0)
                {
                    cellInfo.ItemType = (uint)x.Flag;
                    cellInfo.ItemId = (uint)chapterTemplate.BossExpeditionId[Random.Shared.Next(chapterTemplate.BossExpeditionId.Length)];
                }

                return cellInfo;
            }).ToList();
            var born = chapterTemplate.GridItems.Find(x => x.Flag == ChapterAttachFlag.AttachBorn);
            var chapter = new Currentchapterinfo()
            {
                Id = req.Id,
                Time = (uint)new DateTimeOffset(DateTime.Now.AddSeconds(chapterTemplate.Time)).ToUnixTimeSeconds(),
                CellLists = cells,
                GroupLists = req.GroupIdLists.Select(x =>
                {
                    var fleet = connection.player.Fleets.Find(y => y.Id == x);

                    return new Groupinchapter()
                    {
                        Id = x,
                        ShipLists = fleet?.ShipLists.Select(x => new Shipinchapter() { Id = x, HpRant = 10000 }).ToList(),
                        Pos = new Chaptercellpos() { Column = born.Column, Row = born.Row },
                        Bullet = 5,
                        StartPos = new(),
                        FleetId = x
                    };
                }).ToList(),
                IsSubmarineAutoAttack = 1,
                InitShipCount = (uint)connection.player.Fleets.Where(x => req.GroupIdLists.Contains(x.Id)).Sum(x => x.ShipLists.Count)
            };

            if (connection.player.ChapterInfoes.Any(x => x.Id == chapter.Id))
            {
                connection.player.ChapterInfoes.Remove(connection.player.ChapterInfoes.First(x => x.Id == chapter.Id));
            }
            connection.player.ChapterInfoes.Add(ChapterInfo.FromProto(chapter, connection.player.Uid));
            connection.player.CurrentChapter = chapter.Id;

            connection.Send(new Sc13102()
            {
                CurrentChapter = chapter
            });
        }

        [PacketHandler(Command.Cs13103)]
        static void ChapterOPHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs13103>();
            var rsp = new Sc13104();

            var currentChapter = connection.player.ChapterInfoes.FirstOrDefault(x => x.Id == connection.player.CurrentChapter);
            switch ((ChapterOP)req.Act)
            {
                case ChapterOP.OpRetreat:
                    connection.player.CurrentChapter = null;
                    break;
                case ChapterOP.OpMove:
                    // TODO: Use pathfinding
                    rsp.MovePaths.Add(new() { Row = req.ActArg1, Column = req.ActArg2 });
                    break;
                case ChapterOP.OpEnemyRound:
                    break;
                case ChapterOP.OpBox:
                case ChapterOP.OpAmbush:
                case ChapterOP.OpStrategy:
                case ChapterOP.OpRepair:
                case ChapterOP.OpSupply:
                case ChapterOP.OpSubState:
                case ChapterOP.OpStory:
                case ChapterOP.OpBarrier:
                case ChapterOP.OpSubTeleport:
                case ChapterOP.OpPreClear:
                case ChapterOP.OpRequest:
                case ChapterOP.OpSwitch:
                case ChapterOP.OpSkipBattle:
                    rsp.Result = 1;
                    connection.c.Error($"{nameof(Cs13103)}, {JSON.Stringify(req)}");
                    break;
            }

            connection.Send(rsp);
        }

        [PacketHandler(Command.Cs13106)]
        static void ChapterBattleResultRequestHandler(Connection connection, Packet packet)
        {
            var rsp = new Sc13105();
            var currentChapter = connection.player.ChapterInfoes.FirstOrDefault(x => x.Id == connection.player.CurrentChapter);
            if (currentChapter is null || !Data.ChapterTemplate.TryGetValue((int)currentChapter.Id, out var chapterTemplate))
            {
                connection.Send(rsp);
                return;
            }

            currentChapter.KillCount++;
            if (currentChapter.KillCount >= chapterTemplate.BossRefresh)
            {
                int bossId = chapterTemplate.BossExpeditionId[Random.Shared.Next(chapterTemplate.BossExpeditionId.Length)];
                var bossGridItem = chapterTemplate.GridItems.Find(x => x.Flag == ChapterAttachFlag.AttachBoss);
                var bossCell = currentChapter.CellLists.Find(x => x.Pos.Row == bossGridItem.Row && x.Pos.Column == bossGridItem.Column);
                if (bossCell is not null)
                {
                    bossCell.ItemId = (uint)bossId;
                    bossCell.ItemType = (uint)ChapterAttachFlag.AttachBoss;
                    rsp.MapUpdates.Add(bossCell);
                }
            }

            connection.Send(rsp);
        }

        [PacketHandler(Command.Cs13505)]
        static void RemasterInfoRequestHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc13506());
        }
    }

    static class P13ConnectionNotifyExtensions
    {
        public static void NotifyChapterData(this Connection connection)
        {
            connection.Send(new Sc13001() 
            { 
                ReactChapter = new(), 
                ChapterLists = connection.player.ChapterInfoes.Select(x => x.ToProto()).ToList(),
                CurrentChapter = connection.player.ChapterInfoes.FirstOrDefault(x => x.Id == connection.player.CurrentChapter)?.ToProto(),
            });
        }
    }

    enum ChapterOP
    {
        OpRetreat = 0,
        OpMove = 1,
        OpBox = 2,
        OpAmbush = 4,
        OpStrategy = 5,
        OpRepair = 6,
        OpSupply = 7,
        OpEnemyRound = 8,
        OpSubState = 9,
        OpStory = 10,
        OpBarrier = 16,
        OpSubTeleport = 19,
        OpPreClear = 30,
        OpRequest = 49,
        OpSwitch = 98,
        OpSkipBattle = 99
    }
}

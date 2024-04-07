using BLHX.Server.Common.Proto.common;
using System;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BLHX.Server.Common.Data;
using BLHX.Server.Common.Database;
using BLHX.Server.Common.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLHX.Server.Game.Managers {

    public class BuildManager {

        private static BuildManager instance = null;
        private BuildManager() { }

        public static BuildManager Instance {
            get {
                if (instance == null)
                    instance = new BuildManager();

                return instance;
            }
            set => instance = value;
        }

        public uint BuildCapacity { get; set; } = 10;

        public List<BuildData> BuildData { get; set; } = [];

        public bool BuildShip(uint buildId) {
            DateTime time = DateTime.Now;
            DateTime finishTime = time.AddSeconds(10); // TODO: figure out which cfg is this stored at

            if (BuildData.Count + 1 > BuildCapacity)
                return false;

            BuildData.Add(new BuildData() {
                Pos = (uint)BuildData.Count + 1,
                Tid = 1, // no idea whats this
                BuildId = buildId,
                FinishTime = (uint)new DateTimeOffset(finishTime).ToUnixTimeSeconds(),
                Time = (uint)new DateTimeOffset(time).ToUnixTimeSeconds(),
            });

            return true;
        }

        public bool BatchBuildShip(uint buildId, uint count) {
            if (BuildData.Count + count > BuildCapacity)
                return false;
            
            for (int i = 0; i < count; i++)
                BuildShip(buildId);

            return true;
        }

        public List<Shipinfo> GetBuildResults(List<uint> posList, uint playerUid) { // posList: build position list: so like 1, 2, 3, 4, 5
            List<Shipinfo> buildResults = new List<Shipinfo>();

            foreach (uint buildPosId in posList) {
                BuildData buildData = BuildData[(int)buildPosId - 1];

                Shipinfo receivedShip = CreateShipFromId(HandleGacha(buildData.BuildId), playerUid).ToProto();

                buildResults.Add(receivedShip);
            }

            return buildResults;
        }

        public List<Shipinfo> GetAllBuildResults(uint playerUid) {
            List<uint> posListAll = new List<uint>();

            for (int i = 1; i <= BuildCapacity; i++)
                posListAll.Add((uint)i);

            return GetBuildResults(posListAll, playerUid);
        }

        public uint HandleGacha(uint bannerId) { // for now i changed the entire pool of bannerId = 2 to URs
            uint[] characterPool = Data.ActivityShipCreate[bannerId].PickupList;

            int resultRarity = RNG.NextShipRarity();
            // handle gacha rates here

            return characterPool[RNG.Next(characterPool.Length)];
        }

        // ayo who named these two :skull: 
        public List<BLHX.Server.Common.Proto.p12.BuildInfo> ToInfoLists() {
            return BuildData.Select(data => new BLHX.Server.Common.Proto.p12.BuildInfo() { Pos = data.Pos, Tid = data.Tid }).ToList();
        }

        // this one is not capitalized Build(i)nfo
        public List<BLHX.Server.Common.Proto.common.Buildinfo> ToBuildInfoes() {
            return BuildData.Select(data => new BLHX.Server.Common.Proto.common.Buildinfo() { BuildId = data.BuildId, FinishTime = data.FinishTime, Time = data.Time,}).ToList();
        }

        public void ClearBuilds() {
            BuildData.Clear();
        }

        public static ShipDataStatistics GetShipInfoFromId(uint shipId) {
            return Data.ShipDataStatistics[(int)shipId];
        }

        public static PlayerShip CreateShipFromId(uint shipId, uint playerUid) {
            if (!Data.ShipDataTemplate.TryGetValue((int)shipId, out var shipTemplate))
                throw new InvalidDataException($"Ship template {shipId} not found!");

            var ship = new PlayerShip() {
                TemplateId = shipId,
                Level = 1,
                EquipInfoLists = [
                    new EquipskinInfo() { Id = shipTemplate.EquipId1 },
                    new EquipskinInfo() { Id = shipTemplate.EquipId2 },
                    new EquipskinInfo() { Id = shipTemplate.EquipId3 },
                    new EquipskinInfo(),
                    new EquipskinInfo(),
                ],
                Energy = shipTemplate.Energy,
                SkillIdLists = shipTemplate.BuffList.Select(x => new Shipskill() { SkillId = x, SkillLv = 1 }).ToList(),
                Intimacy = 5000,

                PlayerUid = playerUid
            };

            return ship;
        }

    }

    [PrimaryKey(nameof(Pos))]
    public class BuildData {
        [Key]
        public uint Pos { get; set; }

        public uint Tid { get; set; }

        public uint Time { get; set; }

        public uint FinishTime { get; set; }

        public uint BuildId { get; set; }
    }
}

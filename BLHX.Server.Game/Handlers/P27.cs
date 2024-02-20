using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p27;
using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game.Handlers
{
    internal static class P27
    {
        [PacketHandler(Command.Cs27000)]
        static void EducateHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc27001()
            {
                Child = new()
                {
                    Tid = 1,
                    CurTime = new() { Month = (uint)DateTimeOffset.Now.Month, Week = (uint)DateTime.Now.GetWeekOfMonth(), Day = (uint)DateTimeOffset.Now.AddDays(-1).DayOfWeek },
                    Mood = 50,
                    Money = 20,
                    Attrs = [
                        new ChildAttr() { Id = 101, Val = 0 },
                        new ChildAttr() { Id = 102, Val = 0 },
                        new ChildAttr() { Id = 103, Val = 0 },
                        new ChildAttr() { Id = 104, Val = 0 },
                        new ChildAttr() { Id = 201, Val = 0 },
                        new ChildAttr() { Id = 202, Val = 0 },
                        new ChildAttr() { Id = 203, Val = 0 },
                        new ChildAttr() { Id = 301, Val = 0 },
                        new ChildAttr() { Id = 302, Val = 0 },
                        new ChildAttr() { Id = 303, Val = 0 },
                        new ChildAttr() { Id = 304, Val = 0 },
                        new ChildAttr() { Id = 305, Val = 0 },
                        new ChildAttr() { Id = 306, Val = 0 }
                    ],
                    Favor = new() { Lv = 1, Exp = 0 },
                    Tasks = [
                        new ChildTask() { Id = 101, Progress = 0 },
                        new ChildTask() { Id = 102, Progress = 0 },
                        new ChildTask() { Id = 103, Progress = 0 },
                    ],
                    CanTriggerHomeEvent = 1,
                    NewGamePlusCount = 1
                }
            });
        }

        [PacketHandler(Command.Cs27010)]
        static void EducateEndingsHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc27011());
        }
    }
}

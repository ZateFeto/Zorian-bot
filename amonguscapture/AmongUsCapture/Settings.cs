﻿using System;
using System.IO;
using System.Windows;
using Config.Net;

namespace AmongUsCapture
{
    public static class Settings
    {
        public static string StorageLocation = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\AmongUsCapture");

        public static IConsoleInterface conInterface;

        //Global persistent settings that are saved to a json file. Limited Types
        public static IPersistentSettings PersistentSettings = new ConfigurationBuilder<IPersistentSettings>().UseJsonFile(Path.Join(StorageLocation, "Settings.json")).Build();
        public static IGameOffsets GameOffsets = new ConfigurationBuilder<IGameOffsets>().UseJsonFile(Path.Join(StorageLocation, "GameOffsets.json")).Build();

    }


    public interface IPersistentSettings
    {
        //Types allowed: bool, double, int, long, string, TimeSpan, DateTime, Uri, Guid
        //DateTime is always converted to UTC
        [Option(Alias = "Host", DefaultValue = "http://localhost:8123")]
        string host { get; set; }
        
        [Option(Alias = "DebugConsole", DefaultValue = false)]
        bool debugConsole { get; set; }
        
    }

    public interface IGameOffsets
    {
        //Types allowed: bool, double, int, long, string, TimeSpan, DateTime, Uri, Guid
        //DateTime is always converted to UTC
        
        [Option(Alias = "GameHash", DefaultValue = "74C7DF9C5C722CC641018880F29F2C4C8F52C0720DFC808FD0060D0E7552F192")]
        string GameHash { get; }

        [Option(Alias = "Offsets.Client", DefaultValue = 0x144BB30)]
        int AmongUsClientOffset { get; set; }

        [Option(Alias = "Offsets.GameData", DefaultValue = 0x144BA30)]
        int GameDataOffset { get; set; }

        [Option(Alias = "Offsets.MeetingHud", DefaultValue = 0x144B7CC)]
        int MeetingHudOffset { get; set; }

        [Option(Alias = "Offsets.GameStartManager", DefaultValue = 0x13A715C)]
        int GameStartManagerOffset { get; set; }

        [Option(Alias = "Offsets.HudManager", DefaultValue = 0x139B29C)]
        int HudManagerOffset { get; set; }

        [Option(Alias = "Offsets.ServerManager", DefaultValue = 0x139CF7c)]
        int ServerManagerOffset { get; set; }
    }
}
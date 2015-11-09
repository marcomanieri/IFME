﻿using System;
using System.Collections.Generic;
using System.IO;

using IniParser;
using IniParser.Model;

namespace ifme
{
	public class Profile
	{
		public string File;
		public info Info = new info();
		public picture Picture = new picture();
		public video Video = new video();
		public audio Audio = new audio();

		public static List<Profile> List = new List<Profile>();

		public static void Load()
		{
			List.Clear();

			foreach (var item in Directory.GetFiles(Global.Folder.Profile, "*.ifp"))
			{
				var parser = new FileIniDataParser();
				IniData data = parser.ReadFile(item);

				var p = new Profile();

				p.File = item;
				p.Info.Format = data["info"]["format"];
				p.Info.Platform = data["info"]["platform"];
				p.Info.Name = data["info"]["name"];
				p.Info.Author = data["info"]["author"];
				p.Info.Web = data["info"]["web"];
				p.Picture.Resolution = data["picture"]["resolution"];
				p.Picture.FrameRate = data["picture"]["framerate"];
				p.Picture.BitDepth = Convert.ToInt32(data["picture"]["bitdepth"]);
				p.Picture.Chroma = Convert.ToInt32(data["picture"]["chroma"]);
				p.Video.Preset = data["video"]["preset"];
				p.Video.Tune = data["video"]["tune"];
				p.Video.Type = Convert.ToInt32(data["video"]["type"]);
				p.Video.Value = data["video"]["value"];
				p.Video.Command = data["video"]["cmd"];
				p.Audio.Encoder = data["audio"]["encoder"];
				p.Audio.BitRate = data["audio"]["bitrate"];
				p.Audio.Freq = data["audio"]["frequency"];
				p.Audio.Chan = data["audio"]["channel"];
				p.Audio.Args = data["audio"]["cmd"];

				List.Add(p);
			}
		}

		public class info
		{
			public string Format;
			public string Platform;
			public string Name;
			public string Author;
			public string Web;
		}
	}
}

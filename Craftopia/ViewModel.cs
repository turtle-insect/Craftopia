using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Craftopia
{
	internal class ViewModel : INotifyPropertyChanged
	{
		public CommandAction FileOpenCommand { get; set; }
		public CommandAction FileSaveCommand { get; set; }

		public PlayerSaveJson? Player { get; set; }
		public InGameJson? InGame { get; set; }

		private String mFilename = "";

		public event PropertyChangedEventHandler? PropertyChanged;

		public ViewModel()
		{
			FileOpenCommand = new CommandAction(FileOpen);
			FileSaveCommand = new CommandAction(FileSave);
		}

		private void FileOpen(object? obj)
		{
			var dlg = new OpenFileDialog();
			dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"Low\PocketPair\Craftopia\PPSave\Players";
			if (dlg.ShowDialog() == false) return;

			var save = new SaveData();
			var data = save.Open(dlg.FileName);
			Player = JsonSerializer.Deserialize<PlayerSaveJson>(data["PlayerSave"]);
			InGame = JsonSerializer.Deserialize<InGameJson>(data["InGame"]);
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Player)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InGame)));
			mFilename = dlg.FileName;
		}

		private void FileSave(object? obj)
		{
			var save = new SaveData();
			save.Save(mFilename, new Dictionary<String, String>()
			{
				{"PlayerSave", JsonSerializer.Serialize(Player) },
				{"InGame", JsonSerializer.Serialize(InGame) },
			});
		}
	}
}

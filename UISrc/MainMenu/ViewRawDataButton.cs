using Godot;
using System;

namespace BookCatalog.UISrc.MainMenu
{
	public partial class ViewRawDataButton : Button
	{
		public override void _Pressed()
		{
			GetTree().ChangeSceneToFile("res://Scenes/ViewRawData.tscn");
	
		}
	}
}

using Godot;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalog.Common;
using BookCatalog.Data.Models;
using BookCatalog.Data.Contexts;

namespace BookCatalog.UISrc.DataViews;
public partial class DataGrid : HBoxContainer
{
	public CatalogContext Context;

	public override void _Ready()
	{
		SceneObjects.Grid = this;

		connectDb();
    }

	private void connectDb()
	{
		var folder = "D:\\BookCatalog";
		var path = System.IO.Path.Join(folder, "BookCatalogData.sqlite");

		var connectionString = $"Data Source={path};";

		var contextOptions = new DbContextOptionsBuilder<CatalogContext>()
			.UseSqlite(connectionString)
			.Options;

		Context = new CatalogContext(contextOptions);
	}

	public void Load<TEntity>(List<TEntity> gridData)
	{
		foreach (var x in typeof(TEntity).GetProperties())
		{
			var columnContainer = new ScrollContainer
			{
				HorizontalScrollMode = ScrollContainer.ScrollMode.Disabled,
				VerticalScrollMode = ScrollContainer.ScrollMode.Auto
			};

			var column = new VBoxContainer();
			
			column.AddChild(new Label {Text = x.Name});
			
			foreach (var entity in gridData)
			{
				column.AddSpacer(false);
				column.AddChild(new Label {Text = typeof(TEntity).GetProperty(x.Name)?.GetValue(entity) as string});
				
			}

			columnContainer.AddChild(column);
			AddChild(columnContainer);
		}
	}

	public void Clear()
	{
		foreach (var child in GetChildren())
		{
			child.QueueFree();
		}
	}
}

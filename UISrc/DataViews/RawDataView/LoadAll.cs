using Godot;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalog.Common;
using BookCatalog.Data.Models;
using BookCatalog.Data.Contexts;

namespace BookCatalog.UISrc.DataViews.RawDataView;

public partial class LoadAll : Button
{
    public override void _Pressed()
    {
        var data = SceneObjects.Grid.Context.Books.ToList();
        
        SceneObjects.Grid.Load<BookModel>(data);
    }
}
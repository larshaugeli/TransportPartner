using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransportPartner.Models;

namespace TransportPartner.ViewModels
{
    public class ItemsViewModel
    {
        public List<Item> Items;
        public SelectList Genres;
        public string ItemGenre { get; set; }
        public string SearchString { get; set; }
    }
}

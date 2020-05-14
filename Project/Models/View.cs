using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class View
    {
        public View() { }
        public View(int view)
        {
            this.view = view;
        }

        public int view { get; set; }
    }
}
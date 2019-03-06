using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DXApplication1.models;

namespace DXApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            using(var context =new AppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var car = new CarInfo { CarInfoId = new Guid() ,Name="12"};
                context.CarInfos.Add(car);
                context.SaveChanges();
            }
            Application.Run(new Form1());
        }
    }
}

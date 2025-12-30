using System;
using Gtk;

namespace HashChecker;

public static class Program
{
    public static void Main(string[] args)
    {
        Application.Init();
        var app = new Application("org.hashchecker.app", GLib.ApplicationFlags.None);
        app.Register(GLib.Cancellable.Current);

        var win = new MainWindow();
        app.AddWindow(win);
        win.ShowAll();

        Application.Run();
    }
}

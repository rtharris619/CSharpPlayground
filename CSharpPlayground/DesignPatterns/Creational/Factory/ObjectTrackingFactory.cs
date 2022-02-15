﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.DesignPatterns.Creational.Factory
{
    public class ObjectTrackingFactory
    {
        public void Driver()
        {
            BulkReplacement();
        }

        private void ObjectTracking()
        {
            var factory = new TrackingThemeFactory();
            var theme1 = factory.CreateTheme(false);
            var theme2 = factory.CreateTheme(true);
            WriteLine(factory.Info);
        }

        private void BulkReplacement()
        {
            var factory = new ReplaceableThemeFactory();
            var magicTheme = factory.CreateTheme(true);
            WriteLine(magicTheme.Value.BgrColor);

            factory.ReplaceTheme(false);
            WriteLine(magicTheme.Value.BgrColor);
        }
    }

    public interface ITheme
    {
        string TextColor { get; }
        string BgrColor { get;  }
    }

    class LightTheme : ITheme
    {
        public string TextColor => "black";
        public string BgrColor => "white";
    }

    class DarkTheme: ITheme
    {
        public string TextColor => "white";
        public string BgrColor => "dark gray";
    }

    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ITheme>> themeReferences = new();
        public ITheme CreateTheme(bool dark)
        {
            ITheme theme = dark ? new DarkTheme() : new LightTheme();
            themeReferences.Add(new WeakReference<ITheme>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var reference in themeReferences)
                {
                    if (reference.TryGetTarget(out var theme))
                    {
                        bool dark = theme is DarkTheme;
                        sb.Append(dark ? "Dark" : "Light").AppendLine(" theme");
                    }
                }
                return sb.ToString();
            }
        }
    }

    public class ReplaceableThemeFactory
    {
        private readonly List<WeakReference<Ref<ITheme>>> themes = new();

        private ITheme createThemeImpl(bool dark)
        {
            return dark ? new DarkTheme() : new LightTheme();
        }

        public Ref<ITheme> CreateTheme(bool dark)
        {
            var r = new Ref<ITheme>(createThemeImpl(dark));
            themes.Add(new(r));
            return r;
        }

        public void ReplaceTheme(bool dark)
        {
            foreach (var wr in themes)
            {
                if (wr.TryGetTarget(out var reference))
                {
                    reference.Value = createThemeImpl(dark);
                }
            }
        }
    }

    public class Ref<T> where T : class
    {
        public T Value;

        public Ref(T value)
        {
            Value = value;
        }
    }
}

using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using System;
using System.Drawing;
using Color = System.Drawing.Color;
using System.Collections.Generic;



namespace Volibear
{
    public static class Config
    {
        private static readonly string MenuName = "SK74" + Player.Instance.ChampionName;

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("SK74" + Player.Instance.ChampionName);
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu SpellsMenu, FarmMenu, MiscMenu, DrawMenu;

            static Modes()
            {
                SpellsMenu = Menu.AddSubMenu("::SpellsMenu::");
                Combo.Initialize();
                Harass.Initialize();

                FarmMenu = Menu.AddSubMenu("::FarmMenu::");
                LaneClear.Initialize();
                LastHit.Initialize();

                MiscMenu = Menu.AddSubMenu("::Misc::");
                Misc.Initialize();

                DrawMenu = Menu.AddSubMenu("::Drawings::");
                Draw.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    SpellsMenu.AddGroupLabel("Combo Spells:");
                    _useQ = SpellsMenu.Add("comboQ", new CheckBox("Use Q on Combo ?"));
                    _useW = SpellsMenu.Add("comboW", new CheckBox("Use W on Combo ?"));
                    _useE = SpellsMenu.Add("comboE", new CheckBox("Use E on Combo ?"));
                    _useR = SpellsMenu.Add("comboR", new CheckBox("Use R on Combo ?"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly Slider _manaHarass;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int ManaHarass
                {
                    get { return _manaHarass.CurrentValue; }
                }

                static Harass()
                {
                    SpellsMenu.AddGroupLabel("Harass Spells:");
                    _useQ = SpellsMenu.Add("harassQ", new CheckBox("Use Q on Harass ?"));
                    _useW = SpellsMenu.Add("harassW", new CheckBox("Use W on Harass ?"));
                    _useE = SpellsMenu.Add("harassE", new CheckBox("Use E on Harass ?"));
                    _useR = SpellsMenu.Add("harassR", new CheckBox("Use R on Harass ?"));
                    SpellsMenu.AddGroupLabel("Harass Settings:");
                    _manaHarass = SpellsMenu.Add("harassMana", new Slider("It will only cast any harass spell if the mana is greater than ({0}).", 30));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly Slider _laneMana;
                private static readonly Slider _xCount;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int LaneMana
                {
                    get { return _laneMana.CurrentValue; }
                }

                public static int XCount
                {
                    get { return _xCount.CurrentValue; }
                }

                static LaneClear()
                {
                    FarmMenu.AddGroupLabel("LaneClear Spells:");
                    _useQ = FarmMenu.Add("laneclearQ", new CheckBox("Use Q on Laneclear ?"));
                    _useW = FarmMenu.Add("laneclearW", new CheckBox("Use W on Laneclear ?"));
                    _useE = FarmMenu.Add("laneclearE", new CheckBox("Use E on Laneclear ?"));
                    _useR = FarmMenu.Add("laneclearR", new CheckBox("Use R on Laneclear ?"));
                    FarmMenu.AddGroupLabel("LaneClear Settings:");
                    _laneMana = FarmMenu.Add("laneMana", new Slider("It will only cast any laneclear spell if the mana is greater than ({0}).", 30));
                    _xCount = FarmMenu.Add("xCount", new Slider("It will only cast X spell if it`ll hit ({0}).", 3, 1, 6));
                }

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly Slider _lastMana;
                private static readonly Slider _xCount;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int LastMana
                {
                    get { return _lastMana.CurrentValue; }
                }

                public static int XCount
                {
                    get { return _xCount.CurrentValue; }
                }


                static LastHit()
                {
                    FarmMenu.AddGroupLabel("LastHit Spells:");
                    _useQ = FarmMenu.Add("lasthitQ", new CheckBox("Use Q on LastHit ?"));
                    _useW = FarmMenu.Add("lasthitW", new CheckBox("Use W on LastHit ?"));
                    _useE = FarmMenu.Add("lasthitE", new CheckBox("Use E on LastHit ?"));
                    _useR = FarmMenu.Add("lasthitR", new CheckBox("Use R on LastHit ?"));
                    FarmMenu.AddGroupLabel("LastHit Settings:");
                    _lastMana = FarmMenu.Add("lastMana", new Slider("It will only cast any lasthit spell if the mana is greater than ({0}).", 30));
                    _xCount = FarmMenu.Add("wCount", new Slider("It will only cast X spell if it`ll hit ({0}).", 3, 1, 6));
                }

                public static void Initialize()
                {
                }
            }

            public static class Misc
            {
                private static readonly CheckBox _interruptSpell;
                private static readonly CheckBox _antiGapCloserSpell;
                private static readonly Slider _miscMana;

                public static bool InterruptSpell
                {
                    get { return _interruptSpell.CurrentValue; }
                }

                public static bool AntiGapCloser
                {
                    get { return _antiGapCloserSpell.CurrentValue; }
                }

                public static int MiscMana
                {
                    get { return _miscMana.CurrentValue; }
                }

                static Misc()
                {
                    // Initialize the menu values
                    MiscMenu.AddGroupLabel("Miscellaneous");
                    _interruptSpell = MiscMenu.Add("interruptX", new CheckBox("Use X to interrupt spells ?"));
                    _antiGapCloserSpell = MiscMenu.Add("gapcloserX", new CheckBox("Use X to antigapcloser spells ?"));
                    _miscMana = MiscMenu.Add("miscMana", new Slider("Min mana to use gapcloser/interrupt spells ?", 20));
                }

                public static void Initialize()
                {
                }
            }

            public static class Draw
            {
                private static readonly CheckBox _drawReady;
                private static readonly CheckBox _drawHealth;
                private static readonly CheckBox _drawPercent;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;
                //Color Config
                private static readonly ColorConfig _qColor;
                private static readonly ColorConfig _wColor;
                private static readonly ColorConfig _eColor;
                private static readonly ColorConfig _rColor;
                private static readonly ColorConfig _healthColor;

                //CheckBoxes
                public static bool DrawReady
                {
                    get { return _drawReady.CurrentValue; }
                }

                public static bool DrawHealth
                {
                    get { return _drawHealth.CurrentValue; }
                }

                public static bool DrawPercent
                {
                    get { return _drawPercent.CurrentValue; }
                }

                public static bool DrawQ
                {
                    get { return _drawQ.CurrentValue; }
                }

                public static bool DrawW
                {
                    get { return _drawW.CurrentValue; }
                }

                public static bool DrawE
                {
                    get { return _drawE.CurrentValue; }
                }

                public static bool DrawR
                {
                    get { return _drawR.CurrentValue; }
                }
                //Colors
                public static Color HealthColor
                {
                    get { return _healthColor.GetSystemColor(); }
                }

                public static SharpDX.Color QColor
                {
                    get { return _qColor.GetSharpColor(); }
                }

                public static SharpDX.Color WColor
                {
                    get { return _wColor.GetSharpColor(); }
                }

                public static SharpDX.Color EColor
                {
                    get { return _eColor.GetSharpColor(); }
                }
                public static SharpDX.Color RColor
                {
                    get { return _rColor.GetSharpColor(); }
                }

                static Draw()
                {
                    DrawMenu.AddGroupLabel("Spell drawings Settings :");
                    _drawReady = DrawMenu.Add("drawOnlyWhenReady", new CheckBox("Draw the spells only if they are ready ?"));
                    _drawHealth = DrawMenu.Add("damageIndicatorDraw", new CheckBox("Draw damage indicator ?"));
                    _drawPercent = DrawMenu.Add("percentageIndicatorDraw", new CheckBox("Draw damage percentage ?"));
                    DrawMenu.AddSeparator(1);
                    _drawQ = DrawMenu.Add("qDraw", new CheckBox("Draw Q spell range ?"));
                    _drawW = DrawMenu.Add("wDraw", new CheckBox("Draw W spell range ?"));
                    _drawE = DrawMenu.Add("eDraw", new CheckBox("Draw E spell range ?"));
                    _drawR = DrawMenu.Add("rDraw", new CheckBox("Draw R spell range ?"));

                    _healthColor = new ColorConfig(DrawMenu, "healthColorConfig", Color.Orange, "Color Damage Indicator:");
                    _qColor = new ColorConfig(DrawMenu, "qColorConfig", Color.Blue, "Color Q:");
                    _wColor = new ColorConfig(DrawMenu, "wColorConfig", Color.Red, "Color W:");
                    _eColor = new ColorConfig(DrawMenu, "eColorConfig", Color.DeepPink, "Color E:");
                    _rColor = new ColorConfig(DrawMenu, "rColorConfig", Color.Yellow, "Color R:");
                }

                public static void Initialize()
                {
                }
                public class ColorConfig
                {
                    public Slider RedSlider { get; set; }
                    public Slider BlueSlider { get; set; }
                    public Slider GreenSlider { get; set; }
                    public Slider AlphaSlider { get; set; }
                    private ColorPickerControl ColorPicker { get; set; }

                    public string Id { get; private set; }
                    private static Menu _menu;

                    public ColorConfig(Menu menu, string id, Color color, string GropuLabelName)
                    {
                        Id = id;
                        _menu = menu;
                        Init(color, GropuLabelName);
                    }

                    public void Init(Color color, string name)
                    {
                        RedSlider = new Slider("Red", color.R, 0, 255);
                        GreenSlider = new Slider("Green", color.B, 0, 255);
                        BlueSlider = new Slider("Blue", color.G, 0, 255);
                        AlphaSlider = new Slider("Alpha", color.A, 0, 255);
                        ColorPicker = new ColorPickerControl(Id + "ColorDisplay", color);

                        _menu.AddGroupLabel(name);

                        _menu.Add(Id + "ColorDisplay", ColorPicker);
                        _menu.Add(Id + "Red", RedSlider);
                        _menu.Add(Id + "Green", GreenSlider);
                        _menu.Add(Id + "Blue", BlueSlider);
                        _menu.Add(Id + "Alpha", AlphaSlider);

                        RedSlider.OnValueChange += OnValueChange;
                        GreenSlider.OnValueChange += OnValueChange;
                        BlueSlider.OnValueChange += OnValueChange;
                        AlphaSlider.OnValueChange += OnValueChange;

                        ColorPicker.SetColor(Color.FromArgb(GetValue(ColorBytes.Alpha), GetValue(ColorBytes.Red), GetValue(ColorBytes.Green), GetValue(ColorBytes.Blue)));
                    }

                    private void OnValueChange(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                    {
                        if (sender.DisplayName == RedSlider.DisplayName)
                        {
                            ColorPicker.SetColor(Color.FromArgb(ColorPicker.CurrentValue.A, sender.CurrentValue, ColorPicker.CurrentValue.G, ColorPicker.CurrentValue.B));
                        }
                        if (sender.DisplayName == GreenSlider.DisplayName)
                        {
                            ColorPicker.SetColor(Color.FromArgb(ColorPicker.CurrentValue.A, ColorPicker.CurrentValue.R, sender.CurrentValue, ColorPicker.CurrentValue.B));
                        }
                        if (sender.DisplayName == BlueSlider.DisplayName)
                        {
                            ColorPicker.SetColor(Color.FromArgb(ColorPicker.CurrentValue.A, ColorPicker.CurrentValue.R, ColorPicker.CurrentValue.G, sender.CurrentValue));
                        }
                        if (sender.DisplayName == AlphaSlider.DisplayName)
                        {
                            ColorPicker.SetColor(Color.FromArgb(sender.CurrentValue, ColorPicker.CurrentValue.R, ColorPicker.CurrentValue.G, ColorPicker.CurrentValue.B));
                        }

                    }

                    public ColorBGRA GetSharpColor()
                    {                  //RED,GREEN,BLUE,AA
                        return new ColorBGRA(GetValue(ColorBytes.Red), GetValue(ColorBytes.Green), GetValue(ColorBytes.Blue), GetValue(ColorBytes.Alpha));
                    }

                    public Color GetSystemColor()
                    {
                        return Color.FromArgb(GetValue(ColorBytes.Alpha), GetValue(ColorBytes.Red), GetValue(ColorBytes.Green), GetValue(ColorBytes.Blue));
                    }

                    public byte GetValue(ColorBytes color)
                    {
                        switch (color)
                        {
                            case ColorBytes.Red:
                                return Convert.ToByte(RedSlider.CurrentValue);
                            case ColorBytes.Blue:
                                return Convert.ToByte(BlueSlider.CurrentValue);
                            case ColorBytes.Green:
                                return Convert.ToByte(GreenSlider.CurrentValue);
                            case ColorBytes.Alpha:
                                return Convert.ToByte(AlphaSlider.CurrentValue);
                        }
                        return 255;
                    }
                    private class ColorPickerControl : ValueBase<Color>
                    {
                        private readonly string _name;
                        private Vector2 _offset;
                        private Color SelectedColor { get; set; }

                        private Sprite _colorPickerSprite;
                        private Sprite _colorOverlaySprite;
                        private TextureLoader _textureLoader;

                        public override string VisibleName { get { return _name; } }
                        public override Vector2 Offset { get { return _offset; } }

                        public ColorPickerControl(string uId, Color defaultValue)
                            : base(uId, "", 52)
                        {
                            _name = "";
                            Init(defaultValue);
                        }

                        private static Bitmap ContructColorOverlaySprite()
                        {
                            var bitmap = new Bitmap(30, 30);
                            for (int x = 0; x < 30; x++)
                            {
                                for (int y = 0; y < 30; y++)
                                {
                                    bitmap.SetPixel(x, y, Color.White);
                                }
                            }
                            return bitmap;
                        }

                        public void SetColor(Color color)
                        {
                            SelectedColor = color;
                        }
                        private void Init(Color color)
                        {
                            _offset = new Vector2(0, 10);
                            _textureLoader = new TextureLoader();
                            _colorPickerSprite = new Sprite(_textureLoader.Load("ColorPickerSprite", Resources.ColorPickerSprite));
                            _colorOverlaySprite = new Sprite(_textureLoader.Load("ColorOverlaySprite", ContructColorOverlaySprite()));
                            SelectedColor = color;
                        }

                        public override Color CurrentValue { get { return SelectedColor; } }

                        public override bool Draw()
                        {
                            var rect = new SharpDX.Rectangle((int)MainMenu.Position.X + 160, (int)MainMenu.Position.Y + 95 + 50, 750, 380);
                            if (MainMenu.IsVisible && IsVisible && rect.IsInside(Position))
                            {
                                _colorPickerSprite.Draw(new Vector2(Position.X + 522, Position.Y - 34));
                                _colorOverlaySprite.Color = SelectedColor;
                                _colorOverlaySprite.Draw(new Vector2(Position.X + 522 + 1, Position.Y - 34 + 1));
                                return true;
                            }
                            return false;
                        }

                        public override Dictionary<string, object> Serialize()
                        {
                            return base.Serialize();
                        }
                    }

                    public enum ColorBytes
                    {
                        Red, Green, Blue, Alpha
                    }




                    /// <summary>
                    ///   A strongly-typed resource class, for looking up localized strings, etc.
                    /// </summary>
                    // This class was auto-generated by the StronglyTypedResourceBuilder
                    // class via a tool like ResGen or Visual Studio.
                    // To add or remove a member, edit your .ResX file then rerun ResGen
                    // with the /str option, or rebuild your VS project.
                    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
                    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
                    internal class Resources
                    {

                        private static global::System.Resources.ResourceManager resourceMan;

                        private static global::System.Globalization.CultureInfo resourceCulture;

                        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
                        internal Resources()
                        {
                        }

                        /// <summary>
                        ///   Returns the cached ResourceManager instance used by this class.
                        /// </summary>
                        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
                        internal static global::System.Resources.ResourceManager ResourceManager
                        {
                            get
                            {
                                if (object.ReferenceEquals(resourceMan, null))
                                {
                                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KickassSeries.Properties.Resources", typeof(Resources).Assembly);
                                    resourceMan = temp;
                                }
                                return resourceMan;
                            }
                        }

                        /// <summary>
                        ///   Overrides the current thread's CurrentUICulture property for all
                        ///   resource lookups using this strongly typed resource class.
                        /// </summary>
                        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
                        internal static global::System.Globalization.CultureInfo Culture
                        {
                            get
                            {
                                return resourceCulture;
                            }
                            set
                            {
                                resourceCulture = value;
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap ColorPickerSprite
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("ColorPickerSprite", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap RTBack
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("RTBack", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap RTBottomHUD
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("RTBottomHUD", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap RTTempBar
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("RTTempBar", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap RTTopHUD
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("RTTopHUD", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap STempy
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("STempy", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SThud
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SThud", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerBarrier
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerBarrier", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerBlueSmite
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerBlueSmite", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerClairvoyance
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerClairvoyance", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerClarity
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerClarity", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerCleanse
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerCleanse", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerExhaust
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerExhaust", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerFlash
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerFlash", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerGarrison
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerGarrison", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerGhost
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerGhost", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerHeal
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerHeal", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerIgnite
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerIgnite", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerRedSmite
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerRedSmite", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerSmite
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerSmite", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerSnowBall
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerSnowBall", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap SummonerTeleport
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("SummonerTeleport", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }

                        /// <summary>
                        ///   Looks up a localized resource of type System.Drawing.Bitmap.
                        /// </summary>
                        internal static System.Drawing.Bitmap teste
                        {
                            get
                            {
                                object obj = ResourceManager.GetObject("teste", resourceCulture);
                                return ((System.Drawing.Bitmap)(obj));
                            }
                        }
                    }
                }
            }
        }
    }
}
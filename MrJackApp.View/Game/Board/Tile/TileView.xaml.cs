using MrJackApp.Converter.Game.Board.Tile;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MrJackApp.View.Game.Board.Tile
{
    /// <summary>
    /// Logique d'interaction pour TileView.xaml
    /// </summary>
    public partial class TileView : UserControl
    {
        public PointCollection Points
        {
            get { return (PointCollection)GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }
        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register("Points", typeof(PointCollection), typeof(TileView));

        public TileView()
        {
            InitializeComponent();

            Points = new PointCollection();
            for (int i = 0; i < 6; i++)
                Points.Add(new Point(TileConst.Radius * Math.Cos(i * Math.PI / 3), TileConst.Radius * Math.Sin(i * Math.PI / 3)));
        }
    }
}

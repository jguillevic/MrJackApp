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

            // TODO : Revoir la définition des points pour les faire correspondre au visuel.
            Points = new PointCollection();
            Points.Add(new Point(TileConst.Radius * 2, Math.Sqrt(3) / 2 * TileConst.Radius));
            Points.Add(new Point(TileConst.Radius * 3 / 2, Math.Sqrt(3) * TileConst.Radius));
            Points.Add(new Point(TileConst.Radius / 2, Math.Sqrt(3) * TileConst.Radius));
            Points.Add(new Point(0, Math.Sqrt(3) / 2 * TileConst.Radius));
            Points.Add(new Point(TileConst.Radius / 2, 0));
            Points.Add(new Point(TileConst.Radius * 3 / 2, 0));
        }
    }
}

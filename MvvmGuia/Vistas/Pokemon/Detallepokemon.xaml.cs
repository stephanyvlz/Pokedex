using MvvmGuia.Modelo;
using MvvmGuia.VistaModelo.VMpokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MvvmGuia.Vistas.Pokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detallepokemon : ContentPage
    {
        public Detallepokemon(Mpokemon parametros)
        {
            InitializeComponent();
            BindingContext = new VMdetallepokemoncs(Navigation,parametros);
            ActualizarFondo();
        }

        private void ActualizarFondo()
        {
            var colorPoder = (BindingContext as VMdetallepokemoncs)?.ColorPoder;
            var colorFondo = (BindingContext as VMdetallepokemoncs)?.ColorFondo;

            // Convertir los valores a colores, manejando hexadecimales y nombres de colores
            Color colorPoderFinal = ConvertToColor(colorPoder);
            Color colorFondoFinal = ConvertToColor(colorFondo);

            perro.Background = new LinearGradientBrush
            {
                StartPoint = new Point(1, 0),
                GradientStops = new GradientStopCollection
         {
             new GradientStop
             {
                 Color = colorPoderFinal,
                 Offset = 0.1F
             },
             new GradientStop
             {
                 Color = colorFondoFinal,
                 Offset = 0.8F
             }
         }
            };
        }

        private Color ConvertToColor(string colorValue)
        {
            // Intentar primero con hexadecimal
            if (IsValidHexColor(colorValue))
            {
                return Color.FromHex(colorValue);
            }

            // Si no es hexadecimal, intentar convertir por nombre
            return GetColorFromName(colorValue) ?? Color.Transparent; // Color predeterminado si no se encuentra
        }

        // Método para obtener el color a partir del nombre
        private Color? GetColorFromName(string colorName)
        {
            var colorNames = new Dictionary<string, Color>
     {
         { "red", Color.Red },
         { "green", Color.Green },
         { "blue", Color.Blue },
         { "yellow", Color.Yellow },
         { "black", Color.Black },
         { "white", Color.White },
         { "purple", Color.Purple },
         { "orange", Color.Orange },
         { "pink", Color.FromRgb(255, 192, 203) }, // Color rosa
         // Agrega más colores según sea necesario
     };

            // Intenta obtener el color por nombre
            return colorNames.TryGetValue(colorName.ToLower(), out var color) ? color : (Color?)null;
        }

        // Método para validar si la cadena es un color hexadecimal válido
        private bool IsValidHexColor(string hexColor)
        {
            return !string.IsNullOrEmpty(hexColor) &&
                   (hexColor.Length == 7 || hexColor.Length == 9) && // #RRGGBB o #RRGGBBAA
                   hexColor.StartsWith("#");
        }
    }
}
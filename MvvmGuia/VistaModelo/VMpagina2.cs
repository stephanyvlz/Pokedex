using MvvmGuia.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.VistaModelo
{
    public class VMpagina2 : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Musuarios> listausuarios { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMpagina2(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarusuarios();
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void Mostrarusuarios()
        {
            listausuarios = new List<Musuarios> {
                new Musuarios
                {
                    Nombre = "mapache",
                    Imagen = "https://i.postimg.cc/fL1n6cKC/raccoon.png"
                },
                new Musuarios
                {
                    Nombre = "Cocodrilo",
                    Imagen = "https://i.postimg.cc/XYxMVSLp/crocodile.png"
                },
                new Musuarios
                {
                    Nombre = "rinoseronte",
                    Imagen = "https://i.postimg.cc/tCQGkz7C/rhinoceros.png"
                }
            };
        }
        public async Task Alerta(Musuarios parametros) 
        {
           await DisplayAlert("Titulo",parametros.Nombre,"Ok");
        }
        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        //public ICommand ProcesoSimpcommand => new Command(Mostrarusuarios);
        public ICommand Alertacommand => new Command<Musuarios>(async (p) => await Alerta(p)); 
        #endregion
    }
}

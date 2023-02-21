using Personas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Personas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private Persona PersonaSelec;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                var eliminar = await App.DB.BorrarPersona(PersonaSelec);


                if (eliminar != 0)
                {
                    await DisplayAlert("Aviso", "Registro Eliminado", "Aceptar");
                    listapersonas.ItemsSource = await App.DB.ListaPersona();

                }
                else
                {
                    await DisplayAlert("Aviso", "El registro no pudo ser eliminado", "Aceptar");
                }
            }
            catch
            {
                await DisplayAlert("Aviso", "Por favor seleccione un registro para eliminar", "Aceptar");
            }

        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                var eliminar = await App.DB.ActualizarPersona(PersonaSelec);

                if (eliminar != 0)
                {

                    var pagina = new Views.PageModificar();
                    pagina.BindingContext = PersonaSelec;
                    listapersonas.SelectedItem = null ;
                    await Navigation.PushAsync(pagina);
                
                }

            }
            catch
            {
                await DisplayAlert("Aviso", "Por favor seleccione un registro para actualizar", "Aceptar");
            }

        }


        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PagePersonas());
        }

        

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listapersonas.ItemsSource = await App.DB.ListaPersona();
        }

        private void listapersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var elemento = e.CurrentSelection.FirstOrDefault() as Models.Persona;
            PersonaSelec = (Persona)elemento;

        }
    }
}

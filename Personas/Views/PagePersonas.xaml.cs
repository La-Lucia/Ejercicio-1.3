using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Personas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePersonas : ContentPage
    {
        public PagePersonas()
        {
            InitializeComponent();
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var persona = new Models.Persona
            {
                Nombre = Nombre.Text,
                Apellidos = Apellidos.Text,
                Edad = Convert.ToInt32(Edad.Text),
                Correo= Correo.Text,
                Direccion = Direccion.Text
            };

            if (verificar() == true)
            {

                if (await App.DB.GuardarPersona(persona) > 0)
                {
                    await DisplayAlert("Aviso", "Registro Guardado con exito", "Aceptar");
                    Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Registro no se pudo guardar", "Aceptar");

                }
            }
            else
            {

                await DisplayAlert("Aviso", "Llene todos los campos para guardar un registro", "Aceptar");
            }


            }

        public bool verificar()
        {
            Boolean s;

            if (String.IsNullOrEmpty(Nombre.Text))
            {
                s = false;
            }
            else if (String.IsNullOrEmpty(Apellidos.Text))
            {
                s = false;
            }
            else if (String.IsNullOrEmpty(Edad.Text))
            {
                s = false;
            }
            else if (String.IsNullOrEmpty(Correo.Text))
            {
                s = false;
            }
            else if (String.IsNullOrEmpty(Direccion.Text))
            {
                s = false;
            }
            else
            {
                s = true;
            }


            return s;
        }
    }
}
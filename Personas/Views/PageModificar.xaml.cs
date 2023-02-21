using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Personas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageModificar : ContentPage
    {
        public PageModificar()
        {
            InitializeComponent();
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var persona = new Models.Persona
            {
                Id = Convert.ToInt32(ID.Text),
                Nombre = Nombre.Text,
                Apellidos = Apellidos.Text,
                Edad = Convert.ToInt32(Edad.Text),
                Correo = Correo.Text,
                Direccion = Direccion.Text
            };

            if (verificar() == true)
            {

                if (await App.DB.ActualizarPersona(persona) > 0)
                {
                    await DisplayAlert("Aviso", "Registro Actualizado con exito", "Aceptar");
                    Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Registro no se pudo Actualizar", "Aceptar");

                }

            }
            else {

                await DisplayAlert("Aviso", "Llene todos los campos para actualizar el registro", "Aceptar");
            }
        }

        public bool verificar() {
            Boolean s;

            if (String.IsNullOrEmpty(ID.Text))
            {
                s = false;
            }
            else if (String.IsNullOrEmpty(Nombre.Text))
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
            }else 
            {
                s = true;
            }


            return s;
        }

    }
}
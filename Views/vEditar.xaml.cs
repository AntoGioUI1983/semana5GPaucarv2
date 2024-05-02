namespace semana5GPaucar.Views;
using semana5GPaucar.Models;


    public partial class vEditar : ContentPage
{
    public vEditar(string nombre, int id)
    {
        InitializeComponent();

        // Aqu� puedes inicializar los controles en la p�gina de edici�n con el nombre y el ID recibidos
        txtNombre.Text = nombre;
        lblId.Text = id.ToString();
    }

        private  void btnGuardar_Clicked(object sender, EventArgs e)
        {
            string nuevoNombre = txtNombre.Text;
            int id = int.Parse(lblId.Text);

            if (id > 0) // Verifica si el ID es v�lido
            {
                // El ID es v�lido, por lo que actualizamos la persona existente
                Persona persona = new Persona { Id = id, Name = nuevoNombre };
                App.PersonRepo.UpdatePerson(persona);
            }
            else
            {
                // El ID no es v�lido, por lo que agregamos una nueva persona
                App.PersonRepo.AddNewPerson(nuevoNombre);
            }

            // Mostrar la alerta de �xito
            MostrarAlerta("�xito", "Informaci�n actualizada");
        }

        private async void MostrarAlerta(string titulo, string mensaje)
        {
            await DisplayAlert(titulo, mensaje, "Aceptar");
        }
    }
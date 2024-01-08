using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net.Http;
using System.Security.Policy;

namespace MiWinEscritorio
{
    public partial class Consumiendo : Form
    {
        private string v;

        public Consumiendo()
        {
            InitializeComponent();
        }

        public Consumiendo(string v)
        {
            this.v = v;
        }

        private async void btn_Click(object sender, EventArgs e)
        {

            //string url = "http://www.weliapi.somee.com/ClienteAPI/Listar";
            //using (var httpClient = new HttpClient())
            //{
            //  var response = await httpClient.GetAsync(url);
            //if (response.IsSuccessStatusCode)
            //{
            //  var contenido = await response.Content.ReadAsStringAsync();
            // var employees = JsonSerializer.Deserialize
            //}
            //}



            //    string nombreArchivo = txttexto.Text;
            //    int tipoRespuesta = 2;
            //    string mensajeRespuesta = "";
            //    if (!string.IsNullOrWhiteSpace(nombreArchivo))
            //       {


            //    try
            //      {
            //    using (HttpClient cliente = new HttpClient())
            //     {
            //    string url = "http://www.weliapi.somee.com/ClienteAPI/Listar"+ nombreArchivo;
            //    using (HttpResponseMessage respuestaConsulta = await cliente.GetAsync(url))
            //     {
            //       if (respuestaConsulta.IsSuccessStatusCode) //el error
            //     {
            //    byte[] arrContenido = await respuestaConsulta.Content.ReadAsAsync<byte[]>();
            //    string nombreCompletoArchivo = @"C:\Users\Windows\Documents\SEMESTRE 7\CONSTRUCCION DE SOFTWARE 2\PRUEBAS\"+ nombreArchivo;
            //    File.WriteAllBytes(nombreCompletoArchivo, arrContenido);
            //    tipoRespuesta = 1;
            //      mensajeRespuesta = "se descargo el archivo: " + nombreArchivo;
            //    }
            //     else
            //       {
            //             mensajeRespuesta = await respuestaConsulta.Content.ReadAsStringAsync();

            //           }
            //         }
            //       }
            //     }
            //     catch (Exception ex)
            //     {
            //           tipoRespuesta = 3;
            //             mensajeRespuesta = ex.Message; 

            //      }


            //    }

            //     MessageBoxIcon iconoMensaje;
            //     if(tipoRespuesta == 1)
            //     iconoMensaje = MessageBoxIcon.Information;
            //     else if (tipoRespuesta == 2)
            //        iconoMensaje = MessageBoxIcon.Warning;
            //     else
            //        iconoMensaje = MessageBoxIcon.Error;

            //      MessageBox.Show(mensajeRespuesta, "Descarga de archivo", MessageBoxButtons.OK, iconoMensaje);

           string url = "http://www.weliapi.somee.com/ClienteAPI/Listar";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            var contenido = await response.Content.ReadAsStringAsync();
            //var contenido = await httpClient.GetStringAsync("http://www.weliapi.somee.com/ClienteAPI/Listar");

            txttexto.Text = contenido;
            //string lista = await httpClient.GetStringAsync(url);


            //txttexto.Text = lista;



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

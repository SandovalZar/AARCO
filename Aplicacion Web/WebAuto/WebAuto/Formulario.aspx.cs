using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAuto.Models;
using System.Windows;

namespace WebAuto
{
    public partial class Formulario : System.Web.UI.Page
    {
        int _idMarca = 0;
        int _idSub = 0;
        int _idMod = 0;
        int _idDes = 0;
        int _idSubDes = 0;

        string _peticionDes = "";

        public static List<Descripcion> _descripcion = new List<Descripcion>();

        string _url = ConfigurationManager.AppSettings["url"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IniciarLlenadoDroMarcas();
                IniciarLlenadoDroSubMarcas();
                ddlSubmarca.Items.Insert(0, "Selecciones una Submarca");
                ddlModelo.Items.Insert(0, "Seleccione un Modelo");
                ddlDescripcion.Items.Insert(0, "Seleccione una Descripción");
            }

        }

        public void IniciarLlenadoDroMarcas()
        {
            List<Marca> marcas = null;
            //var mar = new List<Marca>();
            using (var client = new HttpClient())
            {
                Task<HttpResponseMessage> responseMe = client.GetAsync(_url + "Marcas");
                responseMe.Wait();
                HttpResponseMessage resultado = responseMe.Result;
                if (true)
                {
                    Task<string> readTask = resultado.Content.ReadAsStringAsync();
                    readTask.Wait();
                    string json = readTask.Result;
                    marcas = JsonConvert.DeserializeObject<List<Marca>>(json);
                }
                else
                {
                    throw new Exception($"WebAPI. Respondio con error.{resultado.StatusCode}");
                }

                List<SelectListItem> items = marcas.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Nombre,
                        Value = d.Id.ToString(),
                        Selected = false

                    };
                });
            }
            ddlMarca.DataSource = marcas;
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleccionar una Marca", "0"));

            //return marcas;
        }

        public void IniciarLlenadoDroSubMarcas()
        {
            List<Submarca> submarcas = null;
            //var mar = new List<Marca>();
            using (var client = new HttpClient())
            {
                Task<HttpResponseMessage> responseMe = client.GetAsync(_url + "Submarcas/" + _idMarca);
                responseMe.Wait();
                HttpResponseMessage resultado = responseMe.Result;
                if (true)
                {
                    Task<string> readTask = resultado.Content.ReadAsStringAsync();
                    readTask.Wait();
                    string json = readTask.Result;
                    submarcas = JsonConvert.DeserializeObject<List<Submarca>>(json);
                }
                else
                {
                    throw new Exception($"WebAPI. Respondio con error.{resultado.StatusCode}");
                }

                List<SelectListItem> items = submarcas.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Nombre.ToString(),
                        Value = d.Id.ToString(),
                        Selected = false

                    };
                });
            }
            var idddlsu = ddlSubmarca.DataValueField = "Id";
            ddlSubmarca.DataSource = submarcas;
            ddlSubmarca.DataTextField = "Nombre";
            ddlSubmarca.DataValueField = "Id";
            ddlSubmarca.DataBind();
            ddlSubmarca.Items.Insert(0, new ListItem("Seleccionar una Submarca", "0"));

            //return marcas;
        }
        public void IniciarLlenadoDroModelo()
        {
            List<Modelo> modelo = null;
            //var mar = new List<Marca>();
            using (var client = new HttpClient())
            {
                Task<HttpResponseMessage> responseMe = client.GetAsync(_url + "Modeloes/" + _idSub);
                responseMe.Wait();
                HttpResponseMessage resultado = responseMe.Result;
                if (true)
                {
                    Task<string> readTask = resultado.Content.ReadAsStringAsync();
                    readTask.Wait();
                    string json = readTask.Result;
                    modelo = JsonConvert.DeserializeObject<List<Modelo>>(json);
                }
                else
                {
                    throw new Exception($"WebAPI. Respondio con error.{resultado.StatusCode}");
                }

                List<SelectListItem> items = modelo.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Anio.ToString(),
                        Value = d.Id.ToString(),
                        Selected = false

                    };
                });
            }
            ddlModelo.DataSource = modelo;
            ddlModelo.DataTextField = "Anio";
            ddlModelo.DataValueField = "Id";
            ddlModelo.DataBind();
            ddlModelo.Items.Insert(0, new ListItem("Seleccionar un Modelo", "0"));
        }

        public void IniciarLlenadoDroDescripcion(int des)
        {
            _descripcion.Clear();
            //var mar = new List<Marca>();
            using (var client = new HttpClient())
            {
                Task<HttpResponseMessage> responseMe = client.GetAsync(_url + "Descripcions/" + des + "/" + _idMod);
                responseMe.Wait();
                HttpResponseMessage resultado = responseMe.Result;
                if (true)
                {
                    Task<string> readTask = resultado.Content.ReadAsStringAsync();
                    readTask.Wait();
                    string json = readTask.Result;
                    _descripcion = JsonConvert.DeserializeObject<List<Descripcion>>(json);
                }
                else
                {
                    throw new Exception($"WebAPI. Respondio con error.{resultado.StatusCode}");
                }

                List<SelectListItem> items = _descripcion.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Detalles,
                        Value = d.Id.ToString(),
                        Selected = false

                    };
                });


            }
            ddlDescripcion.DataSource = _descripcion;
            ddlDescripcion.DataTextField = "Detalles";
            ddlDescripcion.DataValueField = "Id";
            ddlDescripcion.DataBind();
            ddlDescripcion.Items.Insert(0, new ListItem("Seleccionar una Descripcion", "0"));
        }


        protected void MarcaSeleccionada(object sender, EventArgs e)
        {
            _idMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            ddlSubmarca.ClearSelection();
            ddlDescripcion.ClearSelection();
            ddlModelo.ClearSelection();
            IniciarLlenadoDroSubMarcas();

        }

        protected void SubmarcaSeleccionada(object sender, EventArgs e)
        {
            _idSub = Convert.ToInt32(ddlSubmarca.SelectedValue);
            ddlDescripcion.ClearSelection();
            ddlModelo.ClearSelection();
            IniciarLlenadoDroModelo();
        }

        protected void ModeloSeleccion(object sender, EventArgs e)
        {
            int sub = Convert.ToInt32(ddlSubmarca.SelectedValue);
            _idMod = Convert.ToInt32(ddlModelo.SelectedValue);
            ddlDescripcion.ClearSelection();
            IniciarLlenadoDroDescripcion(sub);
        }

        protected void DescripcionSeleccion(object sender, EventArgs e)
        {
            _idDes = Convert.ToInt32(ddlDescripcion.SelectedValue);
            //string idRequisito = _descripcion.Where(x => x.Id == _idDes).First().DescripcionId;
            //Peticion(idRequisito);
        }

        public void Codigo(int id)
        {
            try
            {
                Catalogo cp = new Catalogo();
                List<CodigoPostal> resultadoCodigo;
                string url = "https://api-test.aarco.com.mx/api-examen/api/examen/sepomex/" + id;
                using (var client = new HttpClient())
                {
                    Task<HttpResponseMessage> responseMe = client.GetAsync(url);
                    responseMe.Wait();
                    HttpResponseMessage resultado = responseMe.Result;
                    if (true)
                    {
                        Task<string> readTask = resultado.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string json = readTask.Result;
                        cp = JsonConvert.DeserializeObject<Catalogo>(json);
                        resultadoCodigo = JsonConvert.DeserializeObject<List<CodigoPostal>>(cp.CatalogoJsonString);
                    }
                    else
                    {
                        throw new Exception($"WebAPI. Respondio con error.{resultado.StatusCode}");
                    }

                    txtEstado.Text = resultadoCodigo[0].Municipio.Estado.sEstado;
                    txtMunicipio.Text = resultadoCodigo[0].Municipio.sMunicipio;

                    ddlColonia.DataSource = resultadoCodigo[0].Ubicacion;
                    ddlColonia.DataTextField = "sUbicacion";
                    ddlColonia.DataValueField = "iIdUbicacion";
                    ddlColonia.DataBind();
                    ddlColonia.Items.Insert(0, new ListItem("Seleccionar una Colonia", "0"));
                }
            }
            catch (Exception)
            {
                lblErrorCP.Text = ("Insert un valor adecuado");
            }
        }

        protected void Peticion(string peticion)
        {
            string remplazo = peticion.Replace("\t", string.Empty);
            remplazo = remplazo.Replace("\"", string.Empty);
            remplazo = remplazo.Replace(" ", string.Empty);


            PeticionDes pet = new PeticionDes() { DescripcionId = remplazo };
            string clave = "";
            string url = "https://api-test.aarco.com.mx/api-examen/api/examen/crear-peticion";
            using (var client = new HttpClient())
            {
                try
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8);
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = client.PostAsync(url, httpContent);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        clave = readTask.Result;
                        PeticionLlave(clave);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        protected void PeticionLlave(string clave)
        {
            //List<Response> responseRes;
            Response responseRes = new Response();
            string remplazo = clave.Replace("\"", string.Empty);

            string url = "https://api-test.aarco.com.mx/api-examen/api/examen/peticion/" + remplazo;
            using (var client = new HttpClient())
            {
                try
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    Task<HttpResponseMessage> responseMe = client.GetAsync(url);
                    
                    responseMe.Wait();
                    HttpResponseMessage resultado = responseMe.Result;
                    if (true)
                    {
                        Task<string> readTask = resultado.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string json = readTask.Result;
                        responseRes = JsonConvert.DeserializeObject<Response>(json);
                    }
                    else
                    {
                        throw new Exception($"WebAPI. Respondio con error.{resultado.StatusCode}");
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                List<Aseguradora> Detalles = responseRes.aseguradoras.ToList();

                List<SelectListItem> items = Detalles.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = (d.Tarifa).ToString(),
                        Value = d.PeticionAseguradoraId.ToString(),
                        Selected = false
                    };
                });

                //ddlejemplo1.DataSource = Detalles;
                //ddlejemplo1.DataTextField = "Tarifa";
                //ddlejemplo1.DataValueField = "PeticionAseguradoraId";
                //ddlejemplo1.DataBind();

                gvcotizar.DataSource = Detalles;
                gvcotizar.DataBind();

            }
        }


        protected void Cotizar(object sender, EventArgs e)
        {
             try
            {
                _idDes = Convert.ToInt32(ddlDescripcion.SelectedValue);
                string idRequisito = _descripcion.Where(x => x.Id == _idDes).First().DescripcionId;

                DescripcionSeleccion(sender, e);
                Peticion(idRequisito);
            }
            catch (Exception)
            {
                //Label1.Text=("Selecciones una marca");
                MessageBox.Show("Selecciones una marca");
            }
        }


        protected void TextoCodigo(object sender, EventArgs e)
        {
            Codigo(Convert.ToInt32(txtCP.Text));
        }

    }
}
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="WebAuto.Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cotizacion</title>
</head>
<header class="p-3 bg-dark text-white">
    <div class="container">
        <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
        </div>
    </div>
</header>
<body class="align-items-center">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row align-items-center">
                <div class="col justify-content-center">
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <h2 class="row">Vehículo</h2>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:DropDownList class="btn btn-warning dropdown-toggle" ErrorMessage="El campo es obligatorio" ID="ddlMarca" runat="server" OnSelectedIndexChanged="MarcaSeleccionada" AutoPostBack="True" BackColor="White" Font-Size="Medium" ForeColor="Black"></asp:DropDownList>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:DropDownList class="btn btn-warning dropdown-toggle" ID="ddlSubmarca" runat="server" OnSelectedIndexChanged="SubmarcaSeleccionada" AutoPostBack="True" BackColor="White" Font-Size="Medium" ForeColor="Black"></asp:DropDownList>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:DropDownList class="btn btn-warning dropdown-toggle" ID="ddlModelo" runat="server" OnSelectedIndexChanged="ModeloSeleccion" AutoPostBack="True" BackColor="White" Font-Size="Medium" ForeColor="Black"></asp:DropDownList>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:DropDownList class="btn btn-warning dropdown-toggle" ID="ddlDescripcion" runat="server" OnSelectedIndexChanged="DescripcionSeleccion" AutoPostBack="True" BackColor="White" Font-Size="Medium" ForeColor="Black"></asp:DropDownList>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <h2>Domicilio</h2>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:TextBox ID="txtCP" runat="server" TextMode="Number" MaxLength="5" AutoPostBack="True" PlaceHolder="Codigo Postal" OnTextChanged="TextoCodigo"></asp:TextBox>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:Label ID="lblErrorCP" class="alert-danger" runat="server" ForeColor="#FF3300"></asp:Label>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:">Estado:</asp:Label>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:TextBox ID="txtEstado" runat="server" Enabled="false" ValidateRequestMode="Enabled">Estado</asp:TextBox>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:Label ID="lblMunicipio" runat="server" Text="Label">Municipio:</asp:Label>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:TextBox ID="txtMunicipio" runat="server" Enabled="false">Municipio</asp:TextBox>
                    </div>
                    <div class="row-cols-3 input-group mb-3 justify-content-center">
                        <asp:DropDownList class="btn btn-warning dropdown-toggle" ID="ddlColonia" runat="server" AutoPostBack="true" ValidateRequestMode="Enabled"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row-cols-3 input-group mb-3 justify-content-center">
                <asp:Button ID="btnCotizar" class="btn btn-outline-success btn-lg" ata-bs-toggle="modal" data-bs-target="#staticBackdropLive" runat="server" Text="Cotizar" OnClick="Cotizar" />
            </div>
            <div class="row-cols-3 input-group mb-3 justify-content-center">
                <button type="button" id="btncotiza" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdropLive" onclick="Ejemplo">
                    Mostrar Modal</button>
            </div>
        </div>




        <div class="modal fade" id="staticBackdropLive" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLiveLabel" style="display: none;" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLiveLabel">Cotizaciones</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>Cotizaciones.</p>
                        <asp:GridView ID="gvcotizar" runat="server" AutoGenerateColumns="false" class="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="AseguradoraId" HeaderText="Asegurador" />
                                <asp:BoundField DataField="Tarifa" HeaderText="Precio" />
                                
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>







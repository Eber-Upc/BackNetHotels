
const Serv = "";
const fecha = new Date();
const añoActual = fecha.getFullYear();
const hoy = fecha.getDate();
const mesActual = fecha.getMonth() + 1;


function GetDateForm() {
    var init = hoy + "/" + mesActual + "/" + añoActual;
    var fin = (hoy + 4) + "/" + mesActual + "/" + añoActual;
    $(function () {
        $('input[name="daterange"]').daterangepicker({
            locale: {
                format: 'DD/MM/YYYY'
            },
            opens: 'left',
            "startDate": init,
            "endDate": fin
        }, function (start, end, label) {
            console.log("A new date selection was made: " + start.format('DD/MM/YYYY') + ' to ' + end.format('DD/MM/YYYY'));
        });
    });
}

function ShowModule(i) {
    if (i == 1) {
        document.getElementById("ModHome").style.display = "block";
        document.getElementById("ModRooms").style.display = "none";
        document.getElementById("ModInfo").style.display = "none";
        document.getElementById("ModResumen").style.display = "none";

    } else if (i == 2) {
        document.getElementById("ModHome").style.display = "none";
        document.getElementById("ModRooms").style.display = "block";
        document.getElementById("ModInfo").style.display = "none";
        document.getElementById("ModResumen").style.display = "none";

    } else if (i == 3) {
        document.getElementById("ModHome").style.display = "none";
        document.getElementById("ModRooms").style.display = "none";
        document.getElementById("ModInfo").style.display = "block";
        document.getElementById("ModResumen").style.display = "none";

    } else if (i == 5) {
        document.getElementById("ModHome").style.display = "none";
        document.getElementById("ModRooms").style.display = "none";
        document.getElementById("ModInfo").style.display = "none";
        document.getElementById("ModResumen").style.display = "block";

    }
    else {
        document.getElementById("ModHome").style.display = "none";
        document.getElementById("ModRooms").style.display = "none";
        document.getElementById("ModInfo").style.display = "none";

        document.getElementById("ModResumen").style.display = "none";

    }
}

function GetViewUserSes() {
    let id = sessionStorage.getItem("id");
    let Vista = document.getElementById("MenUser");
    console.log(id);
    if (id != null) {
        Vista.innerHTML = "<li class='nav-item'><a class='nav-link text-dark' onclick='ViewMyReservas()' >Mis Reservas </a></li> <li class='nav-item'><a class='nav-link text-dark' onclick='LogueaInfOut()' >Cerrar Sesión </a></li>";
    } else {
        Vista.innerHTML = "<li class='nav-item'><a class='nav-link text-dark' onclick='OpenViewLogin()' >Iniciar Sesión </a></li>"
    }
}

function ListarRooms(datos) {
    const vista = document.getElementById("ListRooms");
    const template = document.getElementById("TmpLstRooms").content;
    const fragment = document.createDocumentFragment();
    vista.innerHTML = "";

    datos.forEach(element => {
        //template.document.getElementById("rmTitulo").innerHTML="xxx";
        template.querySelector("img").src = element['img'];
        template.querySelector("h5").textContent = element['titulo'];
        template.querySelector("p").textContent = element['descripcion'];
        //template.querySelector("a").href = "";
        template.querySelector(".btnlink").id=element['id'];
        const clone = template.cloneNode(true);
        fragment.appendChild(clone);
    });
    vista.appendChild(fragment);
}

function EjecucionBuscar() {
    var fechas = document.getElementById("daterange").value;
    var personas = parseInt(document.getElementById("numPerson").value);
    console.log(fechas);
    console.log(personas);
    var params = {
        RangeDate: document.getElementById("daterange").value,
        Personas: personas
    };
    var xmlhttp = new XMLHttpRequest();
    var theUrl = "/api/GetHabitacionesDisponibles";
    xmlhttp.open("POST", theUrl);
    xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xmlhttp.send(JSON.stringify(params));
    xmlhttp.responseType = 'json';
    xmlhttp.onload = function () {
        if (xmlhttp.status != 200) {
            console.log("Error")
        } else {
            console.log(xmlhttp.response);
            ListarRooms(xmlhttp.response);
        }
    };
}

function InfoRoom(datos) {
    localStorage.setItem("room", datos['id']);

    const vista = document.getElementById("InformationRooms");
    const template = document.getElementById("TmpInfRooms").content;
    const fragment = document.createDocumentFragment();
    let Caracter = "";

    template.querySelector("h1").textContent = "Habitacion " + datos['titulo'];
    template.querySelector(".lblDesc").textContent = datos['descripcion'];
    template.querySelector(".lblDesc_b").textContent = datos['descripcion_b'];
    template.querySelector(".lblDesc_c").textContent = datos['descripcion_c'];

    template.querySelector(".img-Principal").src = datos['img'];
    template.querySelector(".img-dos").src = datos['img2'];
    template.querySelector(".img-tres").src = datos['img3'];
    template.querySelector(".img-cuatro").src = datos['img4'];
    template.querySelector(".img-cinco").src = datos['img5'];

    template.querySelector(".lblPrice").textContent = "S/." + datos['costo'] + "/noche";
    template.querySelector(".lblDesde").textContent = "Desde: " + datos['inicio'];
    template.querySelector(".lblHasta").textContent = "Hasta: " + datos['fin'];

    datos.caracteristicas.forEach(element => {
        Caracter += "<li>" + element + "</li>";
    });
    template.querySelector(".lstCaract").innerHTML = Caracter;

    //const clone=template.cloneNode(true);
    fragment.appendChild(template);
    vista.appendChild(fragment);
}

function ShowDetailRoom(idt) {
    var params = {
        Id: parseInt(idt)
    };
    var xmlhttp = new XMLHttpRequest();
    var theUrl = "/api/GetInfoHabitacion";
    xmlhttp.open("POST", theUrl);
    xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xmlhttp.send(JSON.stringify(params));
    xmlhttp.responseType = 'json';
    xmlhttp.onload = function () {
        if (xmlhttp.status != 200) {
            console.log("Error")
        } else {
            GetViewUserSes();
            InfoRoom(xmlhttp.response);
        }
    };
}

function SummaryInfo(datos) {
    console.log(datos);

    const vista = document.getElementById("ViewSummary");
    const template = document.getElementById("TmpSummary").content;
    const fragment = document.createDocumentFragment();

    template.querySelector(".lblHab").textContent = datos['titulo'];
    template.querySelector(".lblCosto").textContent = "Habitacion " + datos['costo'] + "/Noche";
    template.querySelector(".lblinit").textContent = "Desde:  " + datos['inicio'];
    template.querySelector(".lblfin").textContent = "Hasta:  " + datos['fin'];
    template.querySelector(".lblNum").textContent = "Número de Huespedes: " + datos['personas'];
    template.querySelector(".lblTotalDias").textContent = "S/." + datos['costo'] + " x " + datos['dias'] + " días";
    template.querySelector(".lblTotalCosto").textContent = "S/." + datos['totalUnit'];
    template.querySelector(".lblLimpieza").textContent = "S/." + datos['limpieza'];
    template.querySelector(".lblTotal").textContent = "S/." + datos['total'];
    template.querySelector(".img-Principal").src = datos['img'];
    fragment.appendChild(template);
    vista.appendChild(fragment);
}

function MuestraResumen(fechas, Personas, Habitacion) {
    var params = {
        RangeDate: fechas,
        Personas: parseInt(Personas),
        Id: parseInt(Habitacion)
    };
    var xmlhttp = new XMLHttpRequest();
    var theUrl = "/api/GetSummaryReserva";
    //xmlhttp.open("POST", theUrl);
    xmlhttp.open("POST", theUrl);
    xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xmlhttp.send(JSON.stringify(params));
    xmlhttp.responseType = 'json';
    xmlhttp.onload = function () {
        if (xmlhttp.status != 200) {
            console.log("Error")
        } else {
            SummaryInfo(xmlhttp.response);
            
        }
    };
}

function OpenRegistro() {
    document.getElementById("ttlSesion").innerHTML = "Regístrate";
    document.getElementById("descSession").innerHTML = "Coloca tu información para poder registrarte, una vez registrado podras hacer tus reservas";
    document.getElementById("ViewLogin").style.display = "none";
    document.getElementById("viewRegistro").style.display = "block";
}

function OpenLogin() {
    document.getElementById("ttlSesion").innerHTML = "Inicia Sesion";
    document.getElementById("descSession").innerHTML = "Selecciones las fechas en las que desea hospedarse en nuestras instalaciones.";
    document.getElementById("ViewLogin").style.display = "block";
    document.getElementById("viewRegistro").style.display = "none";
}

function RegUsuario() {
    let nombre = document.getElementById("bxNombre").value;
    let apPat = document.getElementById("bxApellidoP").value;
    let apMat = document.getElementById("bxApellidoM").value;
    let tpoDoc = document.getElementById("slcDocumento").value;
    let doc = document.getElementById("bxNumDoc").value;
    let telf = document.getElementById("bxNumTelef").value;
    let dir = document.getElementById("bxDirec").value;
    let dist = document.getElementById("bxDistrito").value;
    let prov = document.getElementById("bxProvincia").value;
    let pass = document.getElementById("bxPass").value;
    let mail = document.getElementById("bxEmail").value;

    var params = {
        Nombre: nombre,
        Apellido_Pat: apPat,
        Apellido_Mat: apMat,
        TipoDocument: tpoDoc,
        NumDocument: doc,
        Direccion: dir,
        Distrito: dist,
        Provincia: prov,
        Mail: mail,
        Telefono: telf,
        UserPass: pass
    };
    var xmlhttp = new XMLHttpRequest();
    var theUrl = "/api/GetRegistroUser";
    xmlhttp.open("POST", theUrl);
    xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xmlhttp.send(JSON.stringify(params));
    xmlhttp.responseType = 'json';
    xmlhttp.onload = function () {
        if (xmlhttp.status != 200) {
            console.log("Error")
        } else {
            console.log(xmlhttp.response);
            let dts = xmlhttp.response;
            if (dts['value'] == "Done") {
                alert("Su usuario fue creado con éxito.. inicie sesión");
                OpenLogin();
            } else {
                alert("Hubo un error con su registro");
            }

            //alert(xmlhttp.response);
        }
    };

}

function LogueaInf() {
    var us = document.getElementById("logEmail").value;
    var ps = document.getElementById("logPass").value;
    if (us != "" || ps != "") {

        var params = {
            UserName: us,
            UserPass: ps
        };
        var xmlhttp = new XMLHttpRequest();
        var theUrl = "/api/GetLoginUsuario";
        xmlhttp.open("POST", theUrl);
        xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        xmlhttp.send(JSON.stringify(params));
        xmlhttp.responseType = 'json';
        xmlhttp.onload = function () {
            if (xmlhttp.status != 200) {
                console.log("Error")
            } else {
                console.log(xmlhttp.response);
                let rsl = xmlhttp.response;
                if (rsl['value'] != "NA" && rsl['value'] != "null") {
                    sessionStorage.setItem("id", rsl['value']);
                    sessionStorage.setItem("nombre", rsl['description']);
                    sessionStorage.setItem("token", rsl['token']);
                    GetViewUserSes();
                    $('#LogModal').modal('hide');
                } else {
                    alert("No se pudo iniciar sesión,Coloque sus datos correctamente");
                }


            }
        };

    } else {
        alert("Debes ingresar todos los datos");
    }

}

function GetSession() {
    var usr = new Object();
    usr.Id = sessionStorage.getItem("id");
    usr.name = sessionStorage.getItem("nombre");
    usr.token = sessionStorage.getItem("token");
    return usr;
}

function OpenViewLogin() {
    $('#LogModal').modal('show');
}

function LogueaInfOut() {
    sessionStorage.clear();
    GetViewUserSes();
}

function openPago() {
    $('#PayMod').modal('show');
}

function sendPago() {
    //alert(sessionStorage.getItem("token"));
    //alert(sessionStorage.getItem("id"));

    var num = document.getElementById("crdNum").value;
    var expM = document.getElementById("crdExpM").value;
    var expY = document.getElementById("crdExpY").value;
    var Ccv = document.getElementById("crdccv").value;
    var Titular = document.getElementById("crdTitular").value;
    var Usr = parseInt(sessionStorage.getItem("id"));
    var Tkn = sessionStorage.getItem("token");
    var Fech = localStorage.getItem("Reserv");
    var Pers = parseInt(localStorage.getItem("Huespedes"));
    var rm = parseInt(localStorage.getItem("room"));
    var params = {
        Number: num,
        Expiry_m: expM,
        Expiry_y: expY,
        Ccv: Ccv,
        Titular: Titular,
        Fechas: Fech,
        Usuario: Usr,
        Token: Tkn,
        Room: rm,
        Huespedes: Pers
    };
    var xmlhttp = new XMLHttpRequest();
    var theUrl = "/api/SetPagoReserva";
    xmlhttp.open("POST", theUrl);
    xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xmlhttp.send(JSON.stringify(params));
    xmlhttp.responseType = 'json';
    xmlhttp.onload = function () {
        if (xmlhttp.status != 200) {
            console.log("Error")
        } else {
            console.log(xmlhttp.response);
            let resp = xmlhttp.response;
            if (resp["value"] == "DONE") {
                document.getElementById("pnlPago").innerHTML = "<center> <div><i class='far fa-check-circle' style='font-size:60px;color:#2ecc71'></i></div> <div> El pago se realizo con éxito</div> </center>";
                document.getElementById("grpBtn").innerHTML = "<center> <button type='button' class='btn btn-secondary' data-bs-dismiss='modal' onclick='index()' >Cerrar </button> </center>";
            } else if (resp["value"] == "NOPGO") {

                document.getElementById("pnlPago").innerHTML = "<center> <div><i class='fas fa-ban' style='font-size:60px;color:#95a5a6'></i></div> <div> El pago no se pudo realizar</div> </center>";
                document.getElementById("grpBtn").innerHTML = "<center> <button type='button' class='btn btn-secondary' data-bs-dismiss='modal' >Cerrar</button> </center>";
            }

        }
    };

}

function ViewMyReservas(datos) {
    $('#MyResvModal').modal('show');
    var params = {
        Id: parseInt(sessionStorage.getItem("id")),
        Token: sessionStorage.getItem("token")
    };
    var xmlhttp = new XMLHttpRequest();
    var theUrl = Serv + "/api/GetHistorialReserva";
    xmlhttp.open("POST", theUrl);
    xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xmlhttp.send(JSON.stringify(params));
    xmlhttp.responseType = 'json';
    xmlhttp.onload = function () {
        if (xmlhttp.status != 200) {
            console.log("Error")
        } else {
            console.log(xmlhttp.response);
            let dts = xmlhttp.response;
            if (dts['habitacion'] != "NULL") {
                const vista = document.getElementById("ListResv");
                const template = document.getElementById("TmpLstResv").content;
                const fragment = document.createDocumentFragment();
                vista.innerHTML = "";
                let i = 1;
                dts.forEach(element => {
                    template.querySelector(".tblCont").textContent = i;
                    template.querySelector(".tblHab").textContent = element['habitacion'];
                    template.querySelector(".tblDesc").textContent = element['descripcion'];
                    template.querySelector(".tblEnt").textContent = element['entrada'];
                    template.querySelector(".tblSal").textContent = element['salida'];
                    template.querySelector(".tblHues").textContent = element['huespedes'];
                    template.querySelector(".tblTot").textContent = element['total'];
                    const clone = template.cloneNode(true);
                    fragment.appendChild(clone);
                    i++;
                });
                vista.appendChild(fragment);
            } else {
                alert("Hubo un error con su registro");
            }

            //alert(xmlhttp.response);
        }
    };
}
index();



function index() {
    GetViewUserSes();
    GetDateForm();
    ShowModule(1);
}

function buscar() {
    GetViewUserSes();
    EjecucionBuscar();
    ShowModule(2);
}

function information(idt) {
    GetViewUserSes();
    ShowDetailRoom(idt);
    ShowModule(3);
}

function resumen() {
    let id = sessionStorage.getItem("id");
    if (id != null) {
        GetViewUserSes();
        let usuario = GetSession();
        if (usuario['Id'] != null) {
            let fechas = localStorage.getItem("Reserv");
            let Personas = localStorage.getItem("Huespedes");
            let Habitacion = localStorage.getItem("room");
            MuestraResumen(fechas, Personas, Habitacion);
            ShowModule(5);
        }
    } else {
        $('#LogModal').modal('show');
    }
}





      
      



      
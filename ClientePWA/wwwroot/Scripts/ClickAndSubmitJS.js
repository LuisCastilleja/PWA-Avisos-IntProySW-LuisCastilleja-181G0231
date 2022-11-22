localStorage.url = "https://pwa-mensajes-181g0231.itesrc.net/api/";

document.addEventListener("click", function (event) {
    
    if (event.target.dataset.add) {
        window.location.replace("/Teachers/AddMessage");
    }
    if (event.target.dataset.update) {
        window.location.replace("/Teachers/UpdateMessage");
    }
    if (event.target.dataset.delete) {
        alert("Pendiente crear un modal para eliminar");
    }
    if (event.target.dataset.details) {
        if (localStorage.idMessage != "") {
            window.location.replace("/Teachers/MessageDetailsTeacher");
        }
        else {
            //Decir que seleccione un mensaje para ver los detalles en un label, luego quito el Alert
            alert("Seleccione un mensaje para ver sus detalles");
        }
    }
    if (event.target.dataset.logout) {
        window.location.replace("/Home/Login");
    }
    if (event.target.dataset.sendmessage) {
        let affair = form.elements["affair"].value;
        let message = form.elements["message"].value;
        console.log(affair);
        console.log(message);
        window.location.replace("/Teachers/Index");
    }
    if (event.target.dataset.cancelteacher) {
        window.location.replace("/Teachers/Index");
    }
    if (event.target.dataset.updatemessage) {
        let affair = form.elements["affair"].value;
        let message = form.elements["message"].value;
        console.log(affair);
        console.log(message);
        window.location.replace("/Teachers/Index");
    }
    if (event.target.dataset.cancelstudent) {
        window.location.replace("/Students/Index");
    }
    if (event.target.dataset.detailsstudent) {
        if (localStorage.studentIdMessage != "") {
            window.location.replace("/Students/MessageDetailsStudent");
        }
        else {
            //Decir que seleccione un mensaje para ver los detalles en un label, luego quito el Alert
            alert("Seleccione un mensaje para ver sus detalles");
        }
    }
});

document.addEventListener("submit", async function (event) {
        //Para cancelar el evento submit, (Override) para poder programar lo que queramos que pase cuando se haga un submit
    event.preventDefault();
    let form = event.target;

    if (event.target.dataset.login) {
        if (form.elements["correo"].value) { 
            if (form.elements["contraseña"].value) {
                let jsonLogin = Object.fromEntries(new FormData(form));
                const requestInfo = {
                    method: "POST",
                    body: JSON.stringify(jsonLogin),
                    mode: 'cors',
                    headers: {
                        'Accept':'application/json',
                        'Content-type': 'application/json',
                        'Access-Control-Allow-Origin': '*',
                        'Access-Control-Allow-Methods': '*'
                    }
                };
                let response = await fetch(`${localStorage.url}${form.dataset.action}`, requestInfo);
                if (response.ok) {
                    //Guardar lo que nos respondio el servidor
                    let credentials = await response.json();
                    //Guardar en localStorage en token
                    localStorage.token = credentials;
                    //Para separar las credenciales en, nombre, id y rol, que esta en string
                    let arrayOfData = credentials.split('.');
                    console.log(arrayOfData);
                    let data = arrayOfData[1];
                    console.log(data);

                    //Decodificar a string el token.
                    var decodeString = atob(data);
                    //Hacer el json con los datos decodificados.
                    var json = JSON.parse(decodeString);
                    //Guardar las credenciales en localStorage
                    //Nombre del usuario
                    localStorage.nameUser = json.name;
                    //Id del usuario
                    localStorage.idUser = json.nameid;
                    //Rol del usuario
                    localStorage.rolUser = json.role;

                    if (localStorage.rolUser == "Profesor") {
                        window.location.replace("/Teachers/Index");
                    }
                    else {
                        window.location.replace("/Students/Index");
                    }
                    form.reset();
                }
                //Sino el status no es ok
                else {
                    console.log(response);
                    console.log(response.body);
                    console.log(response.status);
                    console.log(response.statusText);
                }
            }
            else {
                password.setCustomValidity('Proporcione su contraseña');
                password.reportValidity();
            }
        }
        else {
            email.setCustomValidity('Proporcione su correo electronico');
            email.reportValidity();
        }
       
    }

});
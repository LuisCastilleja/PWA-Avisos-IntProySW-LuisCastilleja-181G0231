localStorage.url = "https://pwa-mensajes-181g0231.itesrc.net/api/";
let label = document.getElementById("errorMessage");
let selectRecipients = document.querySelector(".listOfRecipients");
let jsonMessageDelete = [];

document.addEventListener("click", async function (event) {
    
    if (event.target.dataset.add) {
        window.location.replace("/Teachers/AddMessage");
    }
    if (event.target.dataset.update) {
        if (localStorage.idMessage != "") {
            window.location.replace("/Teachers/UpdateMessage");
        }
        else {
            //Decir que seleccione un mensaje para ver los detalles en un label, luego quito el Alert
            alert("Seleccione un mensaje para editar su informacion");
        }
    }
    if (event.target.dataset.delete) {
        //Para traernos el modal
        let modal = document.getElementById(event.target.dataset.modal);
        //Traernos el formulario del modal
        let form = modal.querySelector("form");
        //Traernos la informacion mas reciente desde la API del mensaje
        if (localStorage.idMessage != "") {
            let response = await fetch(localStorage.url + "Docente/DetallesMensaje/" + localStorage.idMessage);
            if (response.ok) {
                //Nos traemos el mensaje con la informacion
                jsonMessageDelete = await response.json();
                let affairLabel = form.querySelector("label[name=affair]");
                let messageLabel = form.querySelector("label[name=message]");
                let dateLabel = form.querySelector("label[name=dateLabel]");
                //Rellenamos el formulario con la informacion
                affairLabel.innerText = jsonMessageDelete.asunto;
                messageLabel.innerText = jsonMessageDelete.mensajeEnviado;
                //Convertimos la fecha
                let date = new Date(jsonMessageDelete.fechaEnvio).toLocaleDateString();
                dateLabel.innerText = "Fecha de envío: "+ date;
                //Asignamos la fecha al label
          //      form.elements["dateLabel"].innerText = date;
                //Como la lista de destinatario es un string hay que hacerla un arreglo para para asignarla al select
                let listOfRecipients = jsonMessageDelete.destinatarios.split(',');
                listOfRecipients.forEach(value => {
                    let option = document.createElement("option");
                    option.innerText = value;
                    selectRecipients.appendChild(option);
                });
            }
            else {
                console.log(response.statusText);
            }
        }
        else {
                //Decir que seleccione un mensaje para elimnarlo
                alert("Seleccione un mensaje a eliminar");          
        }
        modal.style.display = "block";
        return;
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
    if (event.target.dataset.cancelteacher) {
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
    if (event.target.dataset.cancelupdate) {
        event.target.closest(".modal").style.display = "none";
        selectRecipients.replaceChildren();
        jsonMessageDelete = [];
    }
});

document.addEventListener("submit", async function (event) {
        //Para cancelar el evento submit, (Override) para poder programar lo que queramos que pase cuando se haga un submit
    event.preventDefault();
    let form = event.target;

    //Si quiere iniciar sesion
    if (event.target.dataset.login) {
        let email = form.elements["correo"];
        let errorLabel = form.querySelector(".errorLabel");
        let password = form.elements["contraseña"];
        let input = form.querySelector("input[type=submit]");
        input.disabled = true;
        input.style.opacity = 0.6;
        if (email.value) {
            if (password.value) {
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
                    input.disabled = false;
                    form.reset();
                }
                //Sino el status no es ok
                else {
                    input.disabled = false;
                    input.style.opacity = 1;
                    //Traernos el error
                    let text = await response.text();
                    errorLabel.innerText = text;
                    errorLabel.style.color = "red";
                    errorLabel.style.display = "block";
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

    //SI quiere agregar o editar
    if (event.target.dataset.sendmessage) {
        let affair = form.elements["affair"];
        let message = form.elements["message"];
        let recipients = "";

        if (selectRecipients) {
            //Recorrer el select que tiene los destintarios
            for (let x of selectRecipients.options) {
                //Para ver si estamos recorriendo el ultimo option de la lista de options que tiene el select
                if (x.value == selectRecipients.options[selectRecipients.options.length - 1].value) {
                    //Si era el ultimo option no agregamos la coma
                    recipients = recipients + x.value;
                }
                else {
                    //Si aun no es el ultimo option agregamos la coma
                    recipients = recipients + x.value + ",";
                }
            }
        }
        if (affair.value) {
            if (message.value) {
                let today = new Date();
                today = `${today.getFullYear()}-${parseInt(today.getMonth()) + 1 < 9 ? "0" + parseInt(today.getMonth()) + 1 : parseInt(today.getMonth()) + 1}-${today.getDate() < 10 ? "0" + today.getDate() : today.getDate()}`;
                //Si va a editar
                let jsonMensaje = form.dataset.update ? {
                    id: localStorage.idMessage,
                    asunto: affair.value,
                    mensajeEnviado: message.value,
                    destinatarios: recipients,
                    fkIdDocente: localStorage.idUser,
                    fechaEnvio: today
                } :
                        {
                        //si va a agregar
                        asunto: affair.value,
                        mensajeEnviado: message.value,
                        destinatarios: recipients,
                        fkIdDocente: localStorage.idUser,
                        fechaEnvio: today
                    };
                const requestInfo = {
                    method: "POST",
                    body: JSON.stringify(jsonMensaje),
                    mode: 'cors',
                    headers: {
                        'Accept': 'application/json',
                        'Content-type': 'application/json',
                        'Access-Control-Allow-Origin': '*',
                        'Access-Control-Allow-Methods': '*'
                    }
                };
                let response = await fetch(`${localStorage.url}${form.dataset.action}`, requestInfo);
                if (response.ok) {
                    localStorage.idMessage = "";
                    label.innerText = "";
                    form.reset();
                    window.location.replace("/Teachers/Index");
                }
                else if (response.status == 400) {
                    //Leer el mensaje 
                    let error = await response.text();
                    label.innerText = error;
                }
                else {
                    console.log(response.statusText);
                }

            }
            else {
                message.setCustomValidity('Proporcione el mensaje a enviar');
                message.reportValidity();
            }
        }
        else {
            affair.setCustomValidity('Proporcione el asunto del mensaje');
            affair.reportValidity();
        }
    }

    //Si quiere eliminar
    if (event.target.dataset.delete) {

        if (jsonMessageDelete) {
            const requestInfo = {
                method: "POST",
                body: JSON.stringify(jsonMessageDelete),
                mode: 'cors',
                headers: {
                    'Accept': 'application/json',
                    'Content-type': 'application/json',
                    'Access-Control-Allow-Origin': '*',
                    'Access-Control-Allow-Methods': '*'
                }
            };
            let response = await fetch(`${localStorage.url}${form.dataset.action}`, requestInfo);
            if (response.ok) {
                localStorage.idMessage = "";
                event.target.closest(".modal").style.display = "none";
                selectRecipients.replaceChildren();
                jsonMessageDelete = [];
                form.reset();
            }
            else {
                console.log(response.statusText);
            }
        }            
    }




});
let select = document.querySelector("select");
let h1 = document.querySelector("h1");

getListOfMessages();

function generateList(listMessages) {
    for (i = 0; i < listMessages.length; i++) {
        let option = document.createElement("option");
        option.id = listMessages[i].id;
        let fecha = new Date(listMessages[i].fechaEnvio).toLocaleDateString();
        h1.innerText = "Bienvenido(a)" + " " + localStorage.nameUser;
        option.innerHTML = listMessages[i].asunto + " " + "(" + "Fecha de envio:" + fecha + ")";
        select.appendChild(option);
    }
}

async function getListOfMessages() {
    //Despues cambiar el 1 por el ID del docente para traer los mensajes que ha enviado
    var response = await fetch(localStorage.url + "docente/" + localStorage.idUser);
    if (response.ok) {
        //para tener la informacion en la variable object
        let listOfMessages = await response.json();
        //Lamamos el metodo para generar la lista de mensajes
        generateList(listOfMessages);
    }
    else {
        console.log(result.status);
    }
}

select.addEventListener("click", function (event) {
   localStorage.idMessage = event.target.id;
});


let select = document.querySelector("select");
const url = "https://pwa-mensajes-181g0231.itesrc.net/api/docente/";

function generateList(listMessages) {
    for (i = 0; i < listMessages.length; i++) {
        let option = document.createElement("option");
        let fecha = new Date(listMessages[i].fechaEnvio).toLocaleDateString();
        option.innerHTML = listMessages[i].asunto + " " + "(" + "Fecha de envio:" + fecha + ")";
        select.appendChild(option);
    }
}

async function getListOfMessages() {
    //Despues cambiar el 1 por el ID del docente para traer los mensajes que ha enviado
    var result = await fetch(url + 1);
    if (result.ok) {
        //para tener la informacion en la variable object
        let object = await result.json();
        //Lamamos el metodo para generar la lista de mensajes
        generateList(object);
    }
    else {
        console.log(result.status);
    }
}
getListOfMessages();


var listMessages = [
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"

    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"

    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto cambiado",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"

    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
      {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },

    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },

    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto change",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
    {
        Asunto: "Este es un nuevo asunto changeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee",
        Mensaje: "Mensaje nuevo",
        Fecha: "28/01/2000"
    },
]
let select = document.querySelector("select");
const url = "https://pwa-mensajes-181g0231.itesrc.net/api/docente/";

function generateList() {
    for (let message of listMessages) {
        let option = document.createElement("option");
        option.innerHTML = message.Asunto + " " + "(" + "Fecha de envio:" + " " + message.Fecha + ")";
        select.appendChild(option);
    }
}
generateList();

async function getListOfMessages() {
    //Despues cambiar el 1 por el ID del docente para traer los mensajes que ha enviado
    var result = await fetch(url + 1);
    if (result.ok) {
        //para tener la informacion en la variable object
        let object = await result.json();
        console.log(object);
    }
}
getListOfMessages();


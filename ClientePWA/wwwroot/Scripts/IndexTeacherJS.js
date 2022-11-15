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
let aAdd = document.querySelector(".aAdd");
let aUpdate = document.querySelector(".aUpdate");
let aDelete = document.querySelector(".aDelete");
let aDetails = document.querySelector(".aDetails");
let aLogOut = document.querySelector(".aLogOut");
const url = "https://localhost:44335/api/";

function generateList() {
    for (let message of listMessages) {
        let option = document.createElement("option");
        option.innerHTML = message.Asunto + " " + "(" + "Fecha de envio:" + " " + message.Fecha +")";
        select.appendChild(option);
    }
}
generateList();

aAdd.addEventListener("click", function (event) {
    window.location.replace("/Teachers/AddMessage");
});
aUpdate.addEventListener("click", function (event) {
    window.location.replace("/Teachers/UpdateMessage");
});
aDelete.addEventListener("click", function (event) {
    alert("Pendiente crear un modal para eliminar");
});
aDetails.addEventListener("click", function (event) {
    window.location.replace("/Teachers/MessageDetailsTeacher");
});
aLogOut.addEventListener("click", function (event) {
    window.location.replace("/Home/Login");
});

async function getListOfMessages() {
    //Despues cambiar el 1 por el ID del docente para traer los mensajes que ha enviado
    var result = await fetch(url + "Docente/" + 1);
    if (result.ok) {
        //para tener la informacion en la variable object
        let object = await result.json();
        console.log(object);
    }
}
getListOfMessages();


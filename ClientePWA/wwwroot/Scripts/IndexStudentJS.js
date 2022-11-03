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
let aDetails = document.querySelector(".aDetails");
let aLogOut = document.querySelector(".aLogOut");

function generateList() {
    for (let message of listMessages) {
        let option = document.createElement("option");
        option.innerHTML = message.Asunto + " " + "(" + "Fecha de envio:" + " " + message.Fecha + ")";
        select.appendChild(option);
    }
}
generateList();
aDetails.addEventListener("click", function (event) {
    window.location.replace("/Students/MessageDetailsStudent");
});
aLogOut.addEventListener("click", function (event) {
    window.location.replace("/Home/Login");
});
